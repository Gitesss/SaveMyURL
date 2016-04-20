using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using SaveMyURL.Model;
using SaveMyURL.Service;

namespace SaveMyURL.MVVM
{
    public abstract class BaseGenericService<DBContext, Entity> : BaseService
           where DBContext : ApplicationContext, new()
           where Entity : class, IObjectWithId, new()
    {
        public virtual void InitContex()
        {
            Context = new DBContext();
        }

        //public virtual ICollection<Entity> FindObject(string name)
        //{
        //    Context.Set<Entity>().Where(x => x.)
        //}

        public virtual ICollection<Entity> GetCollection()
        {

            return Context.Set<Entity>().ToList();
        }

        public virtual Entity GetObjectById(int Id)
        {

            return Context.Set<Entity>().FirstOrDefault(x => x.Id == Id) as Entity;
        }

        public virtual bool Delete(object objToDelete)
        {

            try
            {
                Context.Set<Entity>().Remove(objToDelete as Entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;

            }

        }

        public virtual Entity AddNew()
        {
            try
            {
                Entity newObject = new Entity();
                Context.Set<Entity>().Add(newObject);
                return newObject;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return null;
        }

        public virtual bool Add(object objToAdd)
        {
            Entity newObject = objToAdd as Entity;
            Context.Set<Entity>().Add(newObject);
            return true;
        }

        //public void RefreshContext(Entity objectToRefresh)
        //{
        //    //  var objectContext = ((IObjectContextAdapter)this.Context).ObjectContext;
        //    //  objectContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.ClientWins, objectToRefresh);
        //    Context.Entry(objectToRefresh). .Reload();
        //}

        public DbContext Context { get; set; }

        public virtual bool Save()
        {
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }

    }
}
