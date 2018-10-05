using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        private readonly DbContext DbContext;
        public int Save()
        {
            return DbContext.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
        #region Repositories

        #endregion
        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

}
