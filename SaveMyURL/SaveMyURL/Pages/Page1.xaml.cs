using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SaveMyURL.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public Page1()
        {
            this.InitializeComponent();
        }

        public void addMoreOptionsForControlers()
        {

        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridWidth.Width = ListViewIteamWidth.ActualWidth;
        }

    }
}
