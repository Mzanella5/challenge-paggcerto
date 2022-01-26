using Microsoft.EntityFrameworkCore;

namespace challengePaggcerto.src.api.Models.EntityModel
{
    public class DataContext:DbContext
    {
        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<Parcel>? Parcels { get; set; }
        public DbSet<Anticipation>? Anticipations { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            TransactionMap.Map(builder.Entity<Transaction>());
            ParcelMap.Map(builder.Entity<Parcel>());
        }
    }

}