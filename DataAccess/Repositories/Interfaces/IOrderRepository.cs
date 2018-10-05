using DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccess.Repositories.Interfaces
{
   public interface IOrderRepository
    {
        Task Add(OrderViewModel model);
        Task<List<OrderViewModel>> GetAll();
        Task<IPagedList> GetAllPagedList(int pageNumber, int pageSize, string searchstring = null);
    }
}
