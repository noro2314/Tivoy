using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataModels;
using DataAccess.Models;
using System.IO;

namespace DataAccess.Repositories
{
    public class TourRepository : BaseRepository, ITourRepository
    {
        public TourRepository(DbContext context) : base(context)
        { }
        public async Task<List<TourViewModel>> GetAll()
        {
            var items = await (from tr in DbContext.Tours
                               select new TourViewModel
                               {
                                   Id = tr.Id,
                                   Name = tr.Name,
                                   Rate = tr.Rate,
                                   Description = tr.Description,
                                   MoreInfo = tr.MoreInfo,
                                   Review = tr.Review,
                                   Image=tr.Image,
                                   Price=tr.Price
                                   
                               }).ToListAsync();
            return items;
        }

        public async Task<TourViewModel> GetById(int Id)
        {
            return await DbContext.Tours.Where(c => c.Id == Id)
                .Select(c => new TourViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Rate = c.Rate,
                    Description = c.Description,
                    MoreInfo = c.MoreInfo,
                    Review = c.Review,
                    Image = c.Image,
                    Price=c.Price
                }).FirstOrDefaultAsync();
        }

        public async Task Add(TourViewModel model)
        {
            var tour = new Tour
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Rate = model.Rate,
                MoreInfo = model.MoreInfo,
                Image = model.Image,
                Price=model.Price
                
            };
            await DbContext.Tours.AddAsync(tour);
            await DbContext.SaveChangesAsync();            

        }
    }
}
