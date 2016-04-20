using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMyURL.Model
{
    public class Tag : IObjectWithId
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
