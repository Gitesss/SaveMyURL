using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace SaveMyURL.Service
{
    public abstract class BaseService
    {
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

        public virtual bool SaveAsync()
        {
            try
            {
                Context.SaveChangesAsync();
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
