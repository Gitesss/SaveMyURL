using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SaveMyURL.Annotations;
using SaveMyURL.Model;
using SaveMyURL.MVVM;

namespace SaveMyURL.ViewModel
{
    class GroupViewModel : ViewModelBase
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
                    Links = new List<Link>(),
                };

                logic.Add(group);
                logic.Save();

                Groups.Add(group);
            }
        }

        public Command InsertGroupCommand
        {
            get
            {
                return new Command(_ => AddGroup(Name));
            }
        }
    }
}
