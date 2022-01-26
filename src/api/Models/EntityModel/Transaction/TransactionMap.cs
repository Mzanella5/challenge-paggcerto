
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace challengePaggcerto.src.api.Models.EntityModel
{
    public static class TransactionMap
    {
        public static void Map(this EntityTypeBuilder<Transaction> entity)
        {
            entity.Property(t => t.Id).ValueGeneratedOnAdd();
            entity.HasMany(t => t.Parcels).WithOne(p => p.Transaction);
        }
    }

}