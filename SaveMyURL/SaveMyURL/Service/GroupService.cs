using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveMyURL.Model;

namespace SaveMyURL.MVVM
{
    public class GroupService : BaseGenericService<ApplicationContext, Group>
    {
        public GroupService()
        {
            InitContex();
        }

        public Group GetGrupByName(string name)
        {
            return Context.Set<Group>().SingleOrDefault(x => x.Name == name);
        }

    }
}
