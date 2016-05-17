using Intense.Presentation;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using SaveMyURL.Pages;
using SaveMyURL.Presentation;

namespace SaveMyURL
{
    public sealed partial class Shell : UserControl
    {
        public Shell()
        {
            this.InitializeComponent();

            var vm = new ShellViewModel();
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Witam", PageType = typeof(WelcomePage) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Grupy", PageType = typeof(Page1) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Tagi", PageType = typeof(Page2) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Ostatnio usunięte", PageType = typeof(Page3) });

            vm.BottomItems.Add(new NavigationItem { Icon = "", DisplayName = "Ustawienia", PageType = typeof(SettingsPage) });

            // select the first top item
            vm.SelectedItem = vm.TopItems.First();

            this.ViewModel = vm;
        }

        public ShellViewModel ViewModel { get; private set; }

        public Frame RootFrame
        {
            get
            {
                return this.Frame;
            }
        }
    }
}
