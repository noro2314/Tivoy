using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
using DataModels;
using DataAccess.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CustomerRepository:BaseRepository,ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        { }
        public async  Task<int> Add(CustomerViewModel model)
        {
            Customer customer = new Customer
            {
                BirthDate = model.BirthDate,
                FirstName = model.FirstName,
                CityId = model.CityId,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                VisaExpiredate = model.VisaExpiredate,
                UserId = model.UserId,
                Gender = model.Gender,
                PassportIdNumber=model.PassportIdNumber
               
            };
            await DbContext.Customers.AddAsync(customer);
            await DbContext.SaveChangesAsync();
            return customer.Id;
        }
       public async Task<List<CustomerViewModel>> GetAll()
        {
            return await DbContext.Customers.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.User.Email,
                PhoneNumber = c.PhoneNumber,
                CityName = c.City.Name,
                OrderCount=c.Orders.AsQueryable().Count()
                 
            }).ToListAsync();
        }
       public async Task<CustomerViewModel> GetById(int Id)
        {
            return await DbContext.Customers.Where(c => c.Id == Id)
                .Select(c => new CustomerViewModel
                {
                    Id=c.Id,
                    BirthDate=c.BirthDate,
                    FirstName=c.FirstName,
                    LastName=c.LastName,
                    Email=c.User.Email,
                    PhoneNumber=c.PhoneNumber,
                    VisaExpiredate=c.VisaExpiredate,
                    CityName=c.City.Name,
                    Gender=c.Gender,
                    CityId = c.CityId,
                    PassportIdNumber=c.PassportIdNumber,
                    Notes=c.Notes.OrderByDescending(n=>n.AddedDate).Select(n=>new NoteViewModel {Text=n.NoteText,AddDate=n.AddedDate }).ToList(),
                    Orders=c.Orders.Select(o=>new OrderViewModel {Id=o.Id,CreatedDate=o.CreatedDate,StatusId=o.StatusId,TourPrice=o.Tour.Price,TourName=o.Tour.Name}).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task Update(CustomerViewModel model)
        {
            var customer = await DbContext.Customers.FirstOrDefaultAsync(c => c.Id == model.Id);
            if(customer!=null)
            {
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.BirthDate = model.BirthDate;
                customer.CityId = model.CityId;
                customer.Gender = model.Gender;
                customer.PhoneNumber = model.PhoneNumber;
                DbContext.Entry(customer).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
            }
        }
        public async Task AddNote(string text, int userId)
        {
            Note note = new Note
            {
                CustomerId = userId,
                NoteText = text,
                AddedDate=DateTime.Now
            };
            await DbContext.Notes.AddAsync(note);
            await DbContext.SaveChangesAsync();
        }
    }
}
