using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task Add();
        Task GetAll();
        Task GetById();
    }
}
