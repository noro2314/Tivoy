using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
namespace DataAccess.Repositories
{
    public class TourRepository:BaseRepository,ITourRepository
    {
        public TourRepository(DbContext context) : base(context)
        { }
        public async Task GetAll()
        {

        }

        public async Task GetById(int Id)
        {

        }
    }
}
