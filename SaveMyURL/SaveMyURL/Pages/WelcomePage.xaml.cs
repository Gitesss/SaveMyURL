using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Intense.Presentation;
using SaveMyURL.Presentation;

namespace SaveMyURL.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            this.InitializeComponent();
        }

        private void lstViewEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var vm = new ShellViewModel();
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Welcomevcxvxcv", PageType = typeof(WelcomePage) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Page 1vcxvcxv", PageType = typeof(Page1) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Page 2cvcxv", PageType = typeof(Page2) });
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
