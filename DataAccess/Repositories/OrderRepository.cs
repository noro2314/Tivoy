using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
using DataModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using X.PagedList;
using DataModels.Enums;
namespace DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        { }
        public async Task Add(OrderViewModel model)
        {
            var order = new Order
            {
               
                CreatedDate = DateTime.Now,
                CustomerId = model.CustomerId,
                Note = model.Note,
                StatusId = (int)OrderStatusesEnum.Active,
                TourId = model.TourId
            };
            await DbContext.Orders.AddAsync(order);
            await DbContext.SaveChangesAsync();

        }
        public async Task<List<OrderViewModel>> GetAll()
        {
            var orders = await (from o in DbContext.Orders
                                select new OrderViewModel
                                {
                                    Id = o.Id,
                                    CreatedDate = o.CreatedDate,
                                    CustomerId = o.CustomerId,
                                    Note = o.Note,
                                    StatusId = o.StatusId,
                                    TourId = o.TourId
                                }).ToListAsync();
            return orders;
        }
        public async Task<IPagedList> GetAllPagedList(int pageNumber, int pageSize, string searchstring = null)
        {
            var orders = await (from o in DbContext.Orders
                                join c in DbContext.Customers on o.CustomerId equals c.Id
                                where (string.IsNullOrEmpty(searchstring) || o.Id.ToString().Contains(searchstring))
                                select new OrderViewModel
                                {
                                    Id = o.Id,
                                    CreatedDate = o.CreatedDate,
                                    CustomerId = o.CustomerId,
                                    Note = o.Note,
                                    CustomerName = c.FirstName+" "+ c.LastName,
                                    StatusId = o.StatusId,
                                    TourId = o.TourId,
                                    TourName = o.TourId.HasValue ? o.Tour.Name : "",
                                    TourPrice=o.Tour.Price
                                }).ToPagedListAsync(pageNumber, pageSize);
            return orders;
        }

    }
}
