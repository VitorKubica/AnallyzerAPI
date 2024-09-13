using Microsoft.EntityFrameworkCore;
using AnallyzerAPI.Models;

namespace AnallyzerAPI.Database
{
    public class AnallyzerDbContext(DbContextOptions<AnallyzerDbContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<AnallyzerAPI.Models.Campain> Campain { get; set; } = default!;
    }
}
