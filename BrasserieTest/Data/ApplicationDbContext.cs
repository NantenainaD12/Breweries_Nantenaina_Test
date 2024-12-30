using BrasserieTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrasserieTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<WholesalerBeer>()
        //        .HasKey(wb => new { wb.IdBeer, wb.IdWholesaler });

        //    modelBuilder.Entity<WholesalerBeer>()
        //        .HasOne(wb => wb.Beer)
        //        .WithMany(b => b.WholesalerBeers)
        //        .HasForeignKey(wb => wb.IdBeer);

        //    modelBuilder.Entity<WholesalerBeer>()
        //        .HasOne(wb => wb.Wholesaler)
        //        .WithMany(w => w.WholesalerBeers)
        //        .HasForeignKey(wb => wb.IdWholesaler);
        //}


        public DbSet<Brewery> Brewerys { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet <WholesalerBeer> WholesalersBeers { get; set; }
    }
}
