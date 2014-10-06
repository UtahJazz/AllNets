using System;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Windows.Threading;
using AllNets.Twitter;
using AllNets.Vk;
using TweetSharp;

namespace AllNets
{
    public partial class Statistics
    {
        private int _vkFriendsCount;
        private int _twitterFriendsCount;

        public Statistics()
        {
            InitializeComponent();
            GetVkStats();
            GetTwitterStats();
        }

        private void GetTwitterStats()
        {
            var dispatcher = Deployment.Current.Dispatcher;
            var service = TwitterHelper.Authentication();
            service.ListFollowers(new ListFollowersOptions(), (followers, response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _twitterFriendsCount = followers != null ? followers.Count : 0;
                    dispatcher.BeginInvoke(() => TwitterFriends.Text = "Followers in Twitter " + _twitterFriendsCount.ToString(CultureInfo.InvariantCulture));
                }
            });
        }

        private void GetVkStats()
        {
            var reqStr = new Uri(VkApiMethods.VkApi + VkApiMethods.GetAllFriends + VkApiMethods.AccesToken + App.ViewModel.VkMetaData.VkToken 
                + VkApiMethods.OwnerId + App.ViewModel.VkMetaData.UserId);
            var request = (HttpWebRequest)WebRequest.Create(reqStr);
            request.Method = "GET";
            request.AllowAutoRedirect = false;
            request.BeginGetResponse(GetFeedCallback, request);
        }

        void GetFeedCallback(IAsyncResult result)
        {
            var request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    Dispatcher dispatcher = Deployment.Current.Dispatcher;
                    WebResponse response = request.EndGetResponse(result);
                    var serializer = new DataContractJsonSerializer(typeof(FreindsList));
                    var friends = (FreindsList)serializer.ReadObject(response.GetResponseStream());
                    if (friends != null)
                        if (friends.response != null)
                        {
                            _vkFriendsCount = friends.response.Count;
                            dispatcher.BeginInvoke(
                                () => VkFriends.Text = "Friends in VK " + _vkFriendsCount.ToString(CultureInfo.InvariantCulture));
                        }
                }
                catch (WebException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void FeedClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void SendPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddPost.xaml", UriKind.Relative));
        }

        private void Search_CLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        private bool _isSettingsOpen;
        private void ApplicationBarIconButton_OnClick(object sender, EventArgs e)
        {
            if (_isSettingsOpen)
            {
                VisualStateManager.GoToState(this, "SettingsClosedState", true);
                _isSettingsOpen = false;
            }
            else
            {
                VisualStateManager.GoToState(this, "SettingsOpenState", true);
                _isSettingsOpen = true;
            }
        }

        private void TwitterAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TwitterLogIn.xaml", UriKind.Relative));
        }

        private void VkAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AuthotizationPage.xaml", UriKind.Relative));
        }
    }
}