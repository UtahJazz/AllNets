using System;
using System.Windows;
using System.Windows.Navigation;

namespace AllNets
{
    public partial class DetailsPage
    {
        private int _likesCount;
        private int _repostsCount;
        private bool _likesClicked;
        private bool _repostsClicked;

        // Конструктор
        public DetailsPage()
        {
            InitializeComponent();
        }

        // При переходе на страницу установите для контекста данных выбранный элемент в списке
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex;
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    DataContext = App.ViewModel.Items[index];
                    _likesCount = App.ViewModel.Items[index].Likes != null ? App.ViewModel.Items[index].Likes.count : 0;
                    Likes.Content = "Likes " + _likesCount;
                    _repostsCount = App.ViewModel.Items[index].Reposts != null ? App.ViewModel.Items[index].Reposts.count : 0;
                    Reposts.Content = "Reposts " + _repostsCount;
                }
            }
        }

        private void Feed_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
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

        private void Likes_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_likesClicked)
            {
                Likes.Content = "Likes " + (_likesCount + 1);
                _likesClicked = true;
            }
            else
            {
                Likes.Content = "Likes " + _likesCount;
                _likesClicked = false;
            }
        }

        private void VkAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AuthotizationPage.xaml", UriKind.Relative));
        }

        private void TwitterAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TwitterLogIn.xaml", UriKind.Relative));
        }

        private void Reposts_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_repostsClicked)
            {
                Reposts.Content = "Reposts " + (_repostsCount + 1);
                _repostsClicked = true;
            }
            else
            {
                Reposts.Content = "Reposts " + _repostsCount;
                _repostsClicked = false;
            }
        }

        private void Search_CLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        private void SendPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddPost.xaml", UriKind.Relative));
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Statistics.xaml", UriKind.Relative));
        }
    }
}