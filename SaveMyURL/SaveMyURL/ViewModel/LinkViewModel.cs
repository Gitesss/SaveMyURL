using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using SaveMyURL.Model;
using SaveMyURL.MVVM;
using SaveMyURL.Pages;
using SaveMyURL.Service;

namespace SaveMyURL.ViewModel
{
    public class LinkViewModel : ViewModelBase
    {
        #region properties of link
        private int _id = default(int);
        public int Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private byte[] _image;
        public byte[] ImageFromGroup
        {
            get { return _image; }
            set { Set(ref _image, value); }
        }

        private string _description = default(string);
        public string Description
        {

            get { return _description; }
            set { Set(ref _description, value); }
        }

        private int _ratingStars = default(int);
        public int RatingStars
        {
            get { return _ratingStars; }
            set { Set(ref _ratingStars, value); }
        }

        private ObservableCollection<int> _numbers = new ObservableCollection<int>();

        public ObservableCollection<int> Numbers
        {
            get { return _numbers; }
            set
            {
                for (int i = 1; i <= 5; i++)
                {
                    _numbers.Add(i);
                }
            }
        }

        private string _url = default(string);
        public string URL
        {
            get { return _url; }
            set { Set(ref _url, value); }
        }

        private string _text = default(string);
        public string Text
        {
            get { return _text; }
            set { Set(ref _text, value); }
        }

        private DateTime _linkDay = DateTime.Now;
        public DateTime LinkDay
        {
            get { return _linkDay; }
            set { Set(ref _linkDay, value); }
        }

        private ICollection<Tag> _tags;
        public ICollection<Tag> Tags
        {
            get { return _tags; }
            set { Set(ref _tags, value); }
        }
        #endregion

        readonly int groupId;

        public LinkViewModel(Group group)
        {
            GetLinks(group);
            GetTags();
            groupId = group.Id;
            _image = group.Image;
        }

        public LinkViewModel()
        {
            GetLinks();
        }

        private Link _cureentLinkSelected = null;
        public Link CurrentLinkSelected
        {
            get { return _cureentLinkSelected; }
            set
            {
                Set(ref _cureentLinkSelected, value);
                if (_cureentLinkSelected != null)
                {
                    Id = _cureentLinkSelected.Id;
                    URL = _cureentLinkSelected.URL;
                    Description = _cureentLinkSelected.Description;
                    LinkDay = _cureentLinkSelected.DateTime;
                    Tags = _cureentLinkSelected.Tags;
                    RatingStars = _cureentLinkSelected.RatingStars;
                }
                else
                {
                    Id = 0;
                    URL = string.Empty;
                    Description = string.Empty;
                    LinkDay = DateTime.Now;
                    Tags = null;
                    RatingStars = 0;
                }
            }
        }

        // link list
        private ObservableCollection<Link> _links = new ObservableCollection<Link>();
        public ObservableCollection<Link> Links
        {
            get { return _links; }
            set
            {
                Set(ref _links, value);
            }
        }

        private ObservableCollection<Tag> _tagsList = new ObservableCollection<Tag>();
        public ObservableCollection<Tag> TagsList
        {
            get { return _tagsList; }
            set
            {
                Set(ref _tagsList, value);
            }
        }

        private ObservableCollection<Tag> _allTagsList = new ObservableCollection<Tag>();
        public ObservableCollection<Tag> AllTagsList
        {
            get { return _allTagsList; }
            set
            {
                Set(ref _allTagsList, value);
            }
        }

        //private string _linkTags;
        //public string LinkTags
        //{
        //    get { return _linkTags; }
        //    set
        //    {
        //        Set(ref _linkTags, value);

        //        //_linkTags = string.Empty;
        //        //_linkTags = "Tagi: ";

        //        //if (_tagsList != null)
        //        //{
        //        //    foreach (var tag in TagsList)
        //        //    {
        //        //        _linkTags += tag.Name + ",";
        //        //    }
        //        //}
        //    }
        //}

        //private ObservableCollection<Link> _getlinks = new ObservableCollection<Link>();
        //public ObservableCollection<Link> GetLinks
        //{
        //    get { return _getlinks; }
        //    set { Set(ref _getlinks, value); }
        //}

        //private void GetLinks()
        //{
        //    using (var logic = new LinkService())
        //    {
        //        foreach (Link d in logic.GetCollection())
        //        {
        //            Links.Add(d);
        //            int count = Links.Count;
        //        }
        //    }
        //}

        //public ObservableCollection<Group> GetGroupss()
        //{
        //    using (var logic = new GroupService())
        //    {
        //        foreach (var d in logic.GetCollection())
        //        {
        //            Groups.Add(d);
        //        }
        //    }

        //    return Groups;
        //}


        private void GetLinks(Group group)
        {
            using (var logic = new LinkService())
            {
                    foreach (var link in logic.GetCollection(group.Id))
                    {
                        Links.Add(link);
                    }
            }
        }

        private void GetLastLinks()
        {
            using (var logic = new LinkService())
            {
                foreach (var link in logic.GetCollection())
                {
                    Links.Add(link);
                }
            }
        }

        private void GetLinks()
        {
            using (var logic = new LinkService())
            {
                foreach (var link in logic.GetLastAddedlink())
                {
                    Links.Add(link);
                }
            }
        }

        private void GetTags()
        {
            using (var logic = new TagService())
            {
                foreach (var link in Links)
                {
                    foreach (var tag in logic.GetCollection(link.Id))
                    {
                        TagsList.Add(tag);
                    }
                    link.Tags = TagsList;
                }

                foreach (var tag in logic.GetCollectionTags())
                {
                    AllTagsList.Add(tag);
                }
            }
        }

        public async void Addlink(string url)
        {
            URL = url;
            Description = url;
            if (url.Length > 20)
                Description = url.Substring(0, 20);
            RatingStars = 3;

            AddLink addLink = new AddLink();
            addLink.DataContext = this;
            var res = await addLink.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                using (var logic = new LinkService())
                {
                    var link = new Link()
                    {
                        DateTime = DateTime.Now,
                        URL = url,
                        Description = Description,
                        RatingStars = 0,
                        GroupId = groupId,
                        //  Image = await ConvertImageSql.ConvertToBytesAsync(image),
                        Tags = new List<Tag>(),
                    };

                    logic.Add(link);
                    logic.Save();

                    Links.Add(link);
                }

            }

            //var dialog = new MessageDialog("Czy jesteś pewien usunięcia grupy '" + objectToDelete.Name + "' ?");
            //dialog.Title = "Naprawdę?";
            //dialog.Commands.Add(new UICommand { Label = "Tak", Id = 0 });
            //dialog.Commands.Add(new UICommand { Label = "Nie", Id = 1 });
            //var res = await dialog.ShowAsync();

            //if ((int)res.Id == 0)
            //{
            //    using (var logic = new GroupService())
            //    {
            //        logic.DeleteCurrentGroup(objectToDelete);
            //    }
            //    Groups.Remove(objectToDelete);
            //}
        }

        public async void DeleteLink(Link objectToDelete)
        {
            var dialog = new MessageDialog("Czy jesteś pewien usunięcia grupy '" + objectToDelete.Description + "' ?");
            dialog.Title = "Naprawdę?";
            dialog.Commands.Add(new UICommand { Label = "Tak", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Nie", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                using (var logic = new LinkService())
                {
                    logic.Delete(objectToDelete);
                }
                Links.Remove(objectToDelete);
            }
        }


        public Command InsertLinkCommand
        {
            get
            {
                return new Command(_ => Addlink(URL));
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