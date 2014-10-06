using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Serialization;
using AllNets.Twitter;
using AllNets.Vk;
using TweetSharp;

namespace AllNets.ViewModels
{
    public class MainViewModel 
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<PostViewModel>();
            VkMetaData = new VkMetaData();
        }
        public ObservableCollection<PostViewModel> Items { get; private set; }
        private int _id;
        public VkMetaData VkMetaData;

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Load Posts from Twitter and VK to PostViewModel
        /// </summary>
        public void LoadData()
        {
            LoadTokens();
            if (VkMetaData.VkToken != null)
                GetVkFeed();

            GetTwits();
            if (Items.Count > 0)
                IsDataLoaded = true;
            //TODO SORT BY DATE
            Thread.Sleep(100);
        }

        #region VkMethods

        private void GetVkFeed()
        {
            var reqStr =
                new Uri(VkApiMethods.VkApi + VkApiMethods.GetFeed + VkApiMethods.AccesToken + VkMetaData.VkToken
                        + VkMetaData.NewFrom + VkMetaData.Offset + "&count=" + PostsDownloadNumber);
            var request = (HttpWebRequest) WebRequest.Create(reqStr);
            request.Method = "GET";
            request.AllowAutoRedirect = false;
            request.BeginGetResponse(GetFeedCallback, request);

        }

        /// <summary>
        /// Read Vk Api response and deserialize JSON result into RootObject class 
        /// </summary>
        void GetFeedCallback(IAsyncResult result)
        {
                var request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);
                    var serializer = new DataContractJsonSerializer(typeof (RootObject));
                    var newsFeed = (RootObject) serializer.ReadObject(response.GetResponseStream());
                    if (newsFeed.response == null)
                        return;
                    AddVkPostsIntoPostViewModel(newsFeed);
                    VkMetaData.NewFrom = "&from=" + newsFeed.response.new_from;
                    VkMetaData.Offset = "&offset" + newsFeed.response.new_offset;
                }
                catch (WebException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void AddVkPostsIntoPostViewModel(RootObject feed)
        {
            foreach (var post in feed.response.items)
            {
                int sourceId = post.source_id;
                string authorName, authorImage;
                // If sourceId > 0 it's users post, else it's Groups post
                if (sourceId > 0)
                {
                    var profile = feed.response.profiles.First(p => p.uid == sourceId);
                    authorName = profile.first_name + " " + profile.last_name;
                    authorImage = profile.photo;
                }
                else
                {
                    var group = feed.response.groups.First(g => g.gid == (-1)*sourceId);
                    authorName = group.name;
                    authorImage = group.photo;
                }

                var currentPost = new VkPost(post.date, authorName, post.text, authorImage,
                    post.post_id, post.likes, post.reposts, post.attachment);
                Dispatcher dispatcher = Deployment.Current.Dispatcher;
                dispatcher.BeginInvoke(() =>
                {
                    if (Items.ToList().All(p => p.SourceText != post.text))
                    {
                        Items.Add(new PostViewModel(currentPost, _id++));
                    }
                });
            }
        }

        /// <summary>
        /// Read VK Authentication Token and UserId from file
        /// </summary>
        public void LoadTokens()
        {
            var s = new XmlSerializer(typeof(List<string>));
            if (!File.Exists(Windows.Storage.ApplicationData.Current.LocalFolder + "vk.xml"))
                return;
            var fs = new FileStream(Windows.Storage.ApplicationData.Current.LocalFolder + "vk.xml", FileMode.Open);
            var tmp = (List<string>)s.Deserialize(fs);
            VkMetaData.VkToken = tmp[0];
            VkMetaData.UserId = tmp[1];
            fs.Close();
        }

        #endregion

        #region TwitterMethods
        private void GetTwits()
        {
            Dispatcher dispatcher = Deployment.Current.Dispatcher;
            var service = TwitterHelper.Authentication();
            var options = (Items.Count() != 0)
                ? new ListTweetsOnHomeTimelineOptions {Count = PostsDownloadNumber, MaxId = Items.Min(x => x.PostId)}
                : new ListTweetsOnHomeTimelineOptions {Count = PostsDownloadNumber};
            service.ListTweetsOnHomeTimeline(options, (tweets, response) =>
            {
                if (response.Error != null)
                {
                    //MessageBox.Show(response.StatusCode.ToString());
                    return;
                }
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    foreach (var twitterStatuse in tweets)
                    {
                        TwitterStatus tweet = twitterStatuse;
                        dispatcher.BeginInvoke(() =>
                        {
                            if (Items.All(t => t.SourceText != tweet.Text))
                            {
                                Items.Add(new PostViewModel(tweet, _id++));
                            }
                        });
                    }
                }
            });
        }

        #endregion

        private const int PostsDownloadNumber = 5;
    }
}