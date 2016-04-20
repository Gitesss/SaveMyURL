using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveMyURL.Model;

namespace SaveMyURL.MVVM
{
    public class LinkService : BaseGenericService<ApplicationContext, Link>
    {
        public LinkService()
        {
            InitContex();
        }

        //public IEnumerable<Link> GetCollection(string nameOfTab)
        //{
        //    return Context.Set<Link>().Where(x => x.Tab.Nazwa == nameOfTab).ToList();
        //}

        public IEnumerable<Link> GetCollection(int idGroup)
        {
            return Context.Set<Group>().FirstOrDefault(x => x.Id == idGroup).Links;
        }
    }
}
