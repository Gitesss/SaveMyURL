using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMyURL.Repositories
{
    public interface IBaseRepository : IDisposable
    {
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
