using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveMyURL.Model;

namespace SaveMyURL.Repositories
{
    public class GroupRepository : EntityRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }


        public override void Add(Group entity)
        {
            base.Add(entity);
            SaveChanges();
        }
    }
}
