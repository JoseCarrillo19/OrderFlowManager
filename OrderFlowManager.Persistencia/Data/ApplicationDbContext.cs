using Microsoft.EntityFrameworkCore;
using OrderFlowManager.Domain.Entities;

namespace OrderFlowManager.Persistencia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
