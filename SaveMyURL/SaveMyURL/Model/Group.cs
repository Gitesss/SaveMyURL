using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveMyURL.MVVM;

namespace SaveMyURL.Model
{
    public class Group : BindableBase ,IObjectWithId
    {
        [Key]
        private int _id;
        public int Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }



        private ICollection<Link> _links;
        public virtual ICollection<Link> Links
        {
            get { return _links; }
            set { Set(ref _links, value); }
        }

        private DateTime _groupDay;
        public DateTime GroupDay
        {
            get { return _groupDay; }
            set { Set(ref _groupDay, value); }
        }

        private byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { Set(ref _image, value); }
        }
    }
}
