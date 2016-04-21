using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Intense.Presentation;
using SaveMyURL.Model;
using SaveMyURL.MVVM;
using SaveMyURL.Presentation;
using SaveMyURL.ViewModel;

namespace SaveMyURL.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {

        GroupViewModel groupViewModel = new GroupViewModel();
        public WelcomePage()
        {
            this.InitializeComponent();
            DataContext = groupViewModel;
        }

        private void lstViewEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
