using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using AllNets.ViewModels;
using Microsoft.Phone.Controls;

namespace AllNets
{
    public partial class MainPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();

            // Задайте для контекста данных элемента управления LongListSelector пример данных
            DataContext = App.ViewModel;
        }

        // Загрузка данных для элементов ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void Search_CLick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        private void VkAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AuthotizationPage.xaml", UriKind.Relative));
        }

        private void TwitterAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TwitterLogIn.xaml", UriKind.Relative));
        }

        private void Feed_OnItemRealized(object sender, ItemRealizationEventArgs e)
        {
            if (FeedLongListSelector.ItemsSource != null)
            {
                App.ViewModel.LoadData();
            }
        }

        // Обработка выбранных элементов, измененных в LongListSelector
        private void FeedLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Если выбранный элемент равен NULL (ничего не выбрано), никакие действия не требуются
            if (FeedLongListSelector.SelectedItem == null)
                return;

            // Переход на новую страницу
            var itemViewModel = FeedLongListSelector.SelectedItem as PostViewModel;
            if (itemViewModel != null)
                NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + itemViewModel.Id, UriKind.Relative));

            // Сброс выбранного элемента в NULL (ничего не выбрано)
            FeedLongListSelector.SelectedItem = null;
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