using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Microsoft.Data.Entity.Metadata.Internal;
using SaveMyURL.Model;
using SaveMyURL.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SaveMyURL.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LinkPage : Page
    {
        private Group selectedGroup;
        private LinkViewModel _linkViewModel;
        public LinkPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            selectedGroup = e.Parameter as Group;
            _linkViewModel = new LinkViewModel(selectedGroup);
            DataContext = _linkViewModel;
            txtGroupName.Text = selectedGroup.Name;
        }

        private async void TargetTextBox_Drop(object sender, DragEventArgs e)
        {
            VisualStateManager.GoToState(this, "Outside", true);
            bool hasText = e.DataView.Contains(StandardDataFormats.Text);
            e.AcceptedOperation = hasText ? DataPackageOperation.Copy : DataPackageOperation.None;
            if (hasText)
            {
                var text = await e.DataView.GetTextAsync();
                //TargetTextBox.Text = text; // here I have error, why? because debuger is fake
                //_linkViewModel.Addlink(TargetTextBox.Text);
                //TargetTextBox.Text = "Dodano text.";
                _linkViewModel.Addlink(text);
            }
            TargetTextBox.Text = String.Empty;
           
        }

        private void TargetTextBox_DragEnter(object sender, DragEventArgs e)
        {
            VisualStateManager.GoToState(this, "Inside", true);
            bool hasText = e.DataView.Contains(StandardDataFormats.Text);
            e.AcceptedOperation = hasText ? DataPackageOperation.Copy : DataPackageOperation.None;
            if (hasText)
            {
                e.DragUIOverride.Caption = "Upuść tutaj text";
            }
        }

        private void TargetTextBox_DragLeave(object sender, DragEventArgs e)
        {
            VisualStateManager.GoToState(this, "Outside", true);
        }
 
        private void TargetTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            //if ( Key == VirtualKey.Enter)
            //{
            //    string hasText = TargetTextBox.Text;
            //    if (hasText != null)
            //    {
            //        _linkViewModel.Addlink(TargetTextBox.Text);
            //    }
            //    TargetTextBox.Text = String.Empty;
            //}
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewIteam.SelectedItem == null)
            {
                var dialog = new MessageDialog("Najpierw zaznacz, a pózniej naciśnij przycisk 'usuń'.");
                dialog.Title = "Błąd?";
                dialog.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                var res = await dialog.ShowAsync();
            }
            else
            {
                _linkViewModel.DeleteLink(ListViewIteam.SelectedItem as Link);
            }
        }
    }
}
