using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
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

        public void DeleteCurrentGroup(Group objectToDelete)
        {
            var group = objectToDelete;
            if (group == null)
                throw new ArgumentNullException();

            Context.Set<Group>().Attach(objectToDelete);
            Context.Set<Group>().Remove(objectToDelete);
            Context.SaveChanges();


        }


    }
}
