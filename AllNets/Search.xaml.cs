using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using AllNets.Vk;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;

namespace AllNets
{
    public partial class Search
    {
        private ObservableCollection<User> _users;

        public Search()
        {
            InitializeComponent();
            _users = new ObservableCollection<User>();
            UsersLongListSelector.ItemsSource = _users;
        }

        private void FeedClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void SendPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddPost.xaml", UriKind.Relative));
        }

        private void TwitterAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TwitterLogIn.xaml", UriKind.Relative));
        }

        private void VkAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AuthotizationPage.xaml", UriKind.Relative));
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Statistics.xaml", UriKind.Relative));
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

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            
            string city = (City.Text != "City") ? ("&hometown=" + City.Text) : "";
            var reqStr = new Uri(VkApiMethods.VkApi + VkApiMethods.GetUsers + VkApiMethods.AccesToken
                + App.ViewModel.VkMetaData.VkToken + "&q=" + Name.Text + city + "&fields=photo_100,screen_name");
            var request = (HttpWebRequest)WebRequest.Create(reqStr);
            request.Method = "GET";
            request.AllowAutoRedirect = false;
            request.BeginGetResponse(GetFeedCallback, request);
            /*UsersLongListSelector.DataContext = _users;
            UsersLongListSelector.Visibility = Visibility.Visible;*/
        }

        /// <summary>
        /// Read Vk Api response and deserialize JSON result into RootObject class 
        /// </summary>
        void GetFeedCallback(IAsyncResult result)
        {
            var dispatcher = Deployment.Current.Dispatcher;
            var webRequest = result.AsyncState as HttpWebRequest;
            if (webRequest != null)
            {
                var response = (HttpWebResponse)webRequest.EndGetResponse(result);
                var baseStream = response.GetResponseStream();
                string json;
                // if you want to read string response
                using (var reader = new StreamReader(baseStream))
                {
                    json = reader.ReadToEnd();
                }
                var res = (JObject)JsonConvert.DeserializeObject(json);
                dynamic tmp = new JsonObject(res);
                dispatcher.BeginInvoke (() =>_users.Clear());
                for (int i = 1; i < 20; i++)
                {
                    int i1 = i;
                    dispatcher.BeginInvoke (() =>_users.Add(new User(tmp.response[i1].first_name, tmp.response[i1].last_name,
                        tmp.response[i1].photo_100, tmp.response[i1].screen_name)));
                }
            }
        }

    }
}