using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using SaveMyURL.Annotations;
using SaveMyURL.Model;
using SaveMyURL.MVVM;

namespace SaveMyURL.ViewModel
{
    public class GroupViewModel : ViewModelBase
    {

        #region properties of group
        private int _id = default(int);
        public int Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private string _name = default(string);
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { Set(ref _image, value); }
        }

        private DateTime _groupDay = DateTime.Now;
        public DateTime GroupDay
        {
            get { return _groupDay; }
            set { Set(ref _groupDay, value); }
        }

        private ICollection<Link> _links;
        public ICollection<Link> Links
        {
            get { return _links; }
            set { Set(ref _links, value); }
        }
        #endregion

        private byte[] buffer;
        public GroupViewModel()
        {
            GetGroups();
        }


        // group selected
        private Group _cureentGroupSelected = null;
        public Group CurrentGroupSelected
        {
            get { return _cureentGroupSelected; }
            set
            {
                Set(ref _cureentGroupSelected, value);
                if (_cureentGroupSelected != null)
                {
                    Id = _cureentGroupSelected.Id;
                    Name = _cureentGroupSelected.Name;
                    Links = _cureentGroupSelected.Links;
                    GroupDay = _cureentGroupSelected.GroupDay;
                }
                else
                {
                    Id = 0;
                    Links = null;
                    Name = string.Empty;
                    GroupDay = DateTime.Now;
                    //DepId = 0;
                }
            }
        }

        // group list
        private ObservableCollection<Group> _groups = new ObservableCollection<Group>();
        public ObservableCollection<Group> Groups
        {
            get { return _groups; }
            set
            {
                Set(ref _groups, value);
            }
        }

        private ObservableCollection<Link> _getlinks = new ObservableCollection<Link>();
        public ObservableCollection<Link> GetLinks
        {
            get { return _getlinks; }
            set { Set(ref _getlinks, value); }
        }

        private void GetGroups()
        {
            using (var logic = new GroupService())
            {
                foreach (var d in logic.GetCollection())
                {
                    Groups.Add(d);
                }
            }
        }

        public ObservableCollection<Group> GetGroupss()
        {
            using (var logic = new GroupService())
            {
                foreach (var d in logic.GetCollection())
                {
                    Groups.Add(d);
                }
            }

            return Groups;
        }
        //private void GetLinks()
        //{
        //    using (var logic = new BusinessLogicContext())
        //    {
        //        foreach (var e in logic.GetEmployees())
        //        {
        //            Employees.Add(e);
        //        }
        //    }
        //}

        private void AddGroup(string name)
        {
            using (var logic = new GroupService())
            {

                var group = new Group()
                {
                    GroupDay = DateTime.Now,
                    Name = name,
                    Image = buffer,
                    Links = new List<Link>(),
                };

                logic.Add(group);
                logic.Save();

                Groups.Add(group);
            }
            buffer = null;
            _image = null;
            _name = null;
        }


        public async void AddImage()
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".bmp");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");

            StorageFile file = await picker.PickSingleFileAsync();

            using (var inputStream = await file.OpenSequentialReadAsync())
            {
                var readStream = inputStream.AsStreamForRead();
                buffer = new byte[readStream.Length];
                await readStream.ReadAsync(buffer, 0, buffer.Length);
            }

            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(buffer);
                    await writer.StoreAsync();
                }
                Image = buffer;
            }
        }

        public async void DeleteGroup(Group objectToDelete)
        {

            var dialog = new MessageDialog("Czy jesteś pewien usunięcia grupy '" + objectToDelete.Name + "' ?");
            dialog.Title = "Naprawdę?";
            dialog.Commands.Add(new UICommand { Label = "Tak", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Nie", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                using (var logic = new GroupService())
                {
                    logic.DeleteCurrentGroup(objectToDelete);
                }
                Groups.Remove(objectToDelete);
            }

        }


        public Command InsertGroupCommand
        {
            get
            {
                return new Command(_ => AddGroup(Name));
            }
        }

        //    public Command DeleteGroupCommand
        //    {
        //        get
        //        {
        //            return new Command((s) =>
        //            {
        //                var a = s.ToString();
        //                DeleteGroup(CurrentGroupSelected.Id);
        //            }, (s) => (CurrentGroupSelected != null));
        //        }
        //    }
    }
}
