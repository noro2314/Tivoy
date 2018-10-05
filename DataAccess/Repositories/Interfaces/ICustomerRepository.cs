using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModels;
namespace DataAccess.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> Add(CustomerViewModel model);
        Task<List<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(int Id);
    }
}
