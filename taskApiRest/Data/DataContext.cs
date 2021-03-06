using Microsoft.EntityFrameworkCore;
using taskApiRest.Models;

namespace taskApiRest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base (options){}

        public DbSet<Ticket> Tickets{get; set;}

        public DbSet<Category> Categories{get; set;}

        
    }
}