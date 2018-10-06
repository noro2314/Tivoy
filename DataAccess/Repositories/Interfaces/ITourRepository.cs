using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModels;
namespace DataAccess.Repositories.Interfaces
{
    public interface ITourRepository
    {
        Task<List<TourViewModel>> GetAll();
        Task<TourViewModel> GetById(int Id);
        Task Add(TourViewModel model)
    }
}
