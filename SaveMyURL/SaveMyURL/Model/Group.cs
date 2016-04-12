using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMyURL.Model
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
