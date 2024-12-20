using Microsoft.EntityFrameworkCore;
using Dima.Core.Models;
using System.Reflection;

namespace Dima.Api.Data
{
    public class AppDbContext : DbContext
    {

        //COLOQUEI 
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
