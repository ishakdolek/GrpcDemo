using GrpcDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrpcDemo.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Phone> Phone { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=user.db");
    }
}