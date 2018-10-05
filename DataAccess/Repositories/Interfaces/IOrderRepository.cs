using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Repositories.Interfaces
{
   public interface IOrderRepository
    {
        Task Add();
        Task GetAll();
    }
}
