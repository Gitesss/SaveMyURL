using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SaveMyURL.Model;
using SaveMyURL.Repositories;
using SaveMyURL.ViewModel;

namespace SaveMyURL.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        private static ApplicationContext db = new ApplicationContext();
        private GroupRepository group = new GroupRepository(db);
        public WelcomePage()
        {
            this.InitializeComponent();

        }

        private void lstViewEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Group MojaNowaGrupa = new Group() { Name = "WszystkoINic" };

            group.Add(MojaNowaGrupa);
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
