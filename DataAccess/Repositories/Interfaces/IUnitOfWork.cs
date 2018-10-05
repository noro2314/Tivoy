using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }

    }
}
