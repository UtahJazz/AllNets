using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Xml.Serialization;
using AllNets.Vk;

namespace AllNets
{
    public partial class AuthotizationPage
    {
        public AuthotizationPage()
        {
            InitializeComponent();
            AuthBrowser.Navigate(new Uri(VkHelper.AuthorizationUrl));
        }

        private void FeedClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }

        private void Search_CLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Statistics.xaml", UriKind.Relative));
        }

        private void SendPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddPost.xaml", UriKind.Relative));
        }

        private void TwitterAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TwitterLogIn.xaml", UriKind.Relative));
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

        private void AuthBrowser_OnLoadCompleted(object sender, NavigationEventArgs e)
        {
            string responceData = e.Uri.OriginalString;
            if (responceData.Contains("access_token"))
            {
                var parameters = responceData.Split('#')[1].Split('&');
                var accessToken = parameters[0].Substring(parameters[0].IndexOf("=", StringComparison.Ordinal)).Remove(0, 1);
                var userId = parameters[2].Substring(parameters[2].IndexOf("=", StringComparison.Ordinal)).Remove(0, 1);
                SaveTokens(accessToken, userId);
            }
        }

        private static void SaveTokens(string token, string userId)
        {
            var data = new List<string> {token, userId};
            var s = new XmlSerializer(typeof(List<string>));
            var fs = new FileStream(Windows.Storage.ApplicationData.Current.LocalFolder + "vk.xml", FileMode.OpenOrCreate);
            s.Serialize(fs, data);
            fs.Flush();
            fs.Close();
        }
    }
}