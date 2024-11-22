using ClaimFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimFlow.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SalesLeadEntity> SalesLead { get; set; }
    }
}
