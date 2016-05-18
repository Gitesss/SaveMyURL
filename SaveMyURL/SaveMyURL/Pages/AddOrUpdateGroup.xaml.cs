using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using SaveMyURL.Model;
using SaveMyURL.ViewModel;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SaveMyURL.Pages
{
    public sealed partial class AddOrUpdateGroup : ContentDialog
    {
        //private FileOpenPicker openPicker = new FileOpenPicker();
        //private GroupViewModel groupViewModel;
        public AddOrUpdateGroup()
        {
            this.InitializeComponent();
           // groupViewModel = new GroupViewModel();

        }

        private async void Ellipse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //openPicker.ViewMode = PickerViewMode.Thumbnail;
            //openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            //openPicker.FileTypeFilter.Add(".jpeg");
            //openPicker.FileTypeFilter.Add(".png");
            //openPicker.FileTypeFilter.Add(".bmp");
            //openPicker.FileTypeFilter.Add(".jpg");

            //StorageFile file = await openPicker.PickSingleFileAsync();
            //if (file != null)
            //{
            //    var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //    var image = new BitmapImage();
            //    image.SetSource(stream);
            //    imageBrush.ImageSource = image;
            //    InitializeComponent();
            //    file.
            //}
            //else
            //{
            //    string error = "Nie wybrano żadnego pliku jpg/png";

            //}
            //groupViewModel.AddImage();
            GroupViewModel group = this.DataContext as GroupViewModel;
            group.AddImage();
        }

        private void Ellipse_PointerMoved(object sender, PointerRoutedEventArgs e)
        {

        }
    }
}
