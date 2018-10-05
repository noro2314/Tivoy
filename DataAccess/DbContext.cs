using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;


namespace DataAccess
{
    public class DbContext:IdentityDbContext<User,Role,int>
    {
        public DbContext(DbContextOptions<DbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        public class DbContextDbFactory : IDesignTimeDbContextFactory<DbContext>
        {
            DbContext IDesignTimeDbContextFactory<DbContext>.CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
                optionsBuilder.UseSqlServer<DbContext>("Server = s5; Database = Tivoy; Trusted_Connection = False; user id=sa;password=sa.123; MultipleActiveResultSets = true");

                return new DbContext(optionsBuilder.Options);
            }
        }
    }
}
