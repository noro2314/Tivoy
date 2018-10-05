using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
namespace DataAccess.Repositories
{
    public class CustomerRepository:BaseRepository,ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        { }
        public async  Task Add()
        {

        }
       public async Task GetAll()
        {

        }
       public async Task GetById()
        {

        }
    }
}
