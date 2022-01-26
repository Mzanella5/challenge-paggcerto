
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace challengePaggcerto.src.api.Models.EntityModel
{
    public static class ParcelMap
    {
        public static void Map(this EntityTypeBuilder<Parcel> entity)
        {
            entity.Property(p => p.Id).ValueGeneratedOnAdd();    
        }
    }

}