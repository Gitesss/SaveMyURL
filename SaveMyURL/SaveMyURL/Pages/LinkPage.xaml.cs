using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
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


        //e.AcceptedOperation = DataPackageOperation.Copy;
        private async void TargetTextBox_Drop(object sender, DragEventArgs e)
        {
            VisualStateManager.GoToState(this, "Outside", true);
            bool hasText = e.DataView.Contains(StandardDataFormats.Text);
            // if the result of the drop is not too important (and a text copy should have no impact on source)
            // we don't need to take the deferral and this will complete the operation faster
            e.AcceptedOperation = hasText ? DataPackageOperation.Copy : DataPackageOperation.None;
            if (hasText)
            {
                var text = await e.DataView.GetTextAsync();
                TargetTextBox.Text += text;
            }
        }

        private void TargetTextBox_DragEnter(object sender, DragEventArgs e)
        {
            /// Change the background of the target
            VisualStateManager.GoToState(this, "Inside", true);
            bool hasText = e.DataView.Contains(StandardDataFormats.Text);
            e.AcceptedOperation = hasText ? DataPackageOperation.Copy : DataPackageOperation.None;
            if (hasText)
            {
                e.DragUIOverride.Caption = "Drop here to insert text";
            }
        }

        private void TargetTextBox_DragLeave(object sender, DragEventArgs e)
        {
            VisualStateManager.GoToState(this, "Outside", true);
        }
    }
}
