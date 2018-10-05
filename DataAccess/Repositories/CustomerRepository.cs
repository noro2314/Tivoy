﻿using System;
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
                Gender = model.Gender
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
                    Gender=c.Gender
                    
                }).FirstOrDefaultAsync();
        }
    }
}
