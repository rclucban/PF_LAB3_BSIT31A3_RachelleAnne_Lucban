using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PF_LAB3.Models;

namespace PF_LAB3.Data
{
    public class GreedDbContext : DbContext
    {
        public GreedDbContext(DbContextOptions<GreedDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
