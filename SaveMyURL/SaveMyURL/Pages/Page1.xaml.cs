using System;
using System.Linq;
using Windows.ApplicationModel.Contacts;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using SaveMyURL.Model;
using SaveMyURL.ViewModel;

namespace SaveMyURL.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {

        private GroupViewModel groupViewModel;
        private Group actualPointerGroup;
        public Page1()
        {
            this.InitializeComponent();
            groupViewModel = new GroupViewModel();
            DataContext = groupViewModel;
        }

        public void addMoreOptionsForControlers()
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            AddOrUpdateGroup add = new AddOrUpdateGroup();
            ListViewIteam.SelectedItem = null;
            add.DataContext = groupViewModel;

            var btn = sender as Button;
            var result = await add.ShowAsync();

            if (result == ContentDialogResult.Primary)
                add.Hide();
            else if (result == ContentDialogResult.Secondary)
                add.Hide();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {


            if (ListViewIteam.SelectedItem == null)
            {
                var dialog = new MessageDialog("Najpierw zaznacz, a pózniej naciśnij przycisk 'usuń'.");
                dialog.Title = "Błąd?";
                dialog.Commands.Add(new UICommand {Label = "OK", Id = 0});
                var res = await dialog.ShowAsync();
            }
            else
            {
                groupViewModel.DeleteGroup(ListViewIteam.SelectedItem as Group);
            }


        }

        private void ListViewIteam_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            Group selectedGroup = (Group) ListViewIteam.SelectedItem;
            this.Frame.Navigate(typeof(LinkPage),selectedGroup);
        }
    }
}
