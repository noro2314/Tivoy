using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
using DataModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

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
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                CustomerId = model.CustomerId,
                Note = model.Note,
                StatusId = model.StatusId,
                TourId = model.TourId
            };
            DbContext.Orders.AddAsync(order);
            await DbContext.SaveChangesAsync();

        }
        public async Task<List<OrderViewModel>> GetAll()
        {
            var orders = await (from o in DbContext.Orders
                                select new OrderViewModel
                                {
                                    Id  =o.Id,
                                    CreatedDate = o.CreatedDate,
                                    CustomerId= o.CustomerId,
                                    Note = o.Note,
                                    StatusId = o.StatusId,
                                    TourId = o.TourId
                                }).ToListAsync();
            return orders;
        }
    }
}
