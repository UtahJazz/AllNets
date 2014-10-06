using System;
using System.Net;
using System.Windows;
using AllNets.Twitter;
using AllNets.Vk;
using TweetSharp;

namespace AllNets
{
    public partial class AddPost
    {
        public AddPost()
        {
            InitializeComponent();
        }

        private void SendVk_Click(object sender, RoutedEventArgs e)
        {
            SendMsgVk();
        }

        private void SendMsgVk()
        {
            var reqStr = new Uri(VkApiMethods.VkApi + VkApiMethods.WallPost + VkApiMethods.AccesToken
                                 + App.ViewModel.VkMetaData.VkToken + VkApiMethods.OwnerId + App.ViewModel.VkMetaData.UserId +
                                 VkApiMethods.Message + Message.Text);
            var request = (HttpWebRequest) WebRequest.Create(reqStr);
            request.Method = "POST";
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
                    request.EndGetResponse(result);
                }
                catch (WebException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void SendAll_Click(object sender, RoutedEventArgs e)
        {
            if (Message.Text.Length > 140)
            {
                MessageBox.Show("Tweet length must be less then 140 letters");
                return;
            }
            SendMsgVk();
            SendMsgTwitter();
        }

        private void SendTwitter_Click(object sender, RoutedEventArgs e)
        {
            SendMsgTwitter();
        }

        private void SendMsgTwitter()
        {
            var service = TwitterHelper.Authentication();
            var opts = new SendTweetOptions {Status = Message.Text};
            service.SendTweet(opts, (tweets, response) => { });
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

        private void Feed_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Statistics.xaml", UriKind.Relative));
        }

        private void Search_CLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
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