using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMyURL.Model
{
    public class Link : IObjectWithId
    {
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public byte[] Image { get; set; }
        public int RatingStars { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public int Id { get; set; }
    }
}
