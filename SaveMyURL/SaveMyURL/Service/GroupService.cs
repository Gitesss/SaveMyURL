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

            Context.Set<Group>().Attach(objectToDelete);//this work only for one obejt but if i have one-to-many this don't work
            Context.Set<Group>().Remove(objectToDelete);
            Context.SaveChanges();


            //foreach (var link in group.Links)
            //{
            //    foreach (var tag in link.Tags)
            //    {
            //        Context.Set<Tag>().Remove(tag);
            //    }
            //    Context.Set<Link>().Remove(link);
            //}
            //Context.Set<Group>().Remove(group);

            //Context.SaveChanges();

        }


    }
}
