using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories;
namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
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
        ITourRepository _itourRepository;
        ICustomerRepository _icustomerRepository;

        public ITourRepository TourRepository => _itourRepository ?? new TourRepository(DbContext);
        public ICustomerRepository CustomerRepository => _icustomerRepository ?? new CustomerRepository(DbContext);

        IOrderRepository _OrderRepository;
        public IOrderRepository OrderRepository => _OrderRepository ?? (_OrderRepository = new OrderRepository(DbContext));
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
