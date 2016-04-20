using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using SaveMyURL.Model;

namespace SaveMyURL.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected ApplicationContext ApplicationContext;

        public BaseRepository(ApplicationContext applicationContext)
        {
            if (applicationContext == null)
            {
                throw new ArgumentException();
            }
            ApplicationContext = applicationContext;
        }
        public void Dispose()
        {
            ApplicationContext.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await ApplicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Error while saving to database", ex);
            }
        }

        public void SaveChanges()
        {
            try
            {
                ApplicationContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Error while saving to database", ex);
            }
        }
    }
}
