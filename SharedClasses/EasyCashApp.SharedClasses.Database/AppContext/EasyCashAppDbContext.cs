using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashApp.SharedClasses.Database.AppContext
{
    public class EasyCashAppDbContext : DbContext
    {
        public EasyCashAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> EC_USERS { get; set; }
        public DbSet<UserDetail> EC_USER_DETAILS { get; set; }
        public DbSet<Dto_CommonResponse> COMMON_RESPONSE { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dto_CommonResponse>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
