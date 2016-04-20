using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveMyURL.Model;
using SaveMyURL.MVVM;

namespace SaveMyURL.Service
{
    public class TagService : BaseGenericService<ApplicationContext,Tag>
    {
        public TagService()
        {
            InitContex();
        }

        public Tag GetTagByName(string tagName)
        {
            return Context.Set<Tag>().SingleOrDefault(x => x.Name == tagName);
        }
    }
}
