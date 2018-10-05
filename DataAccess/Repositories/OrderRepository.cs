using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
namespace DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        { }
        public async Task Add()
        {

        }
        public async Task GetAll()
        {
            //var tours = await (from t in DbContext.
            //                 select new )
        }
    }
}
