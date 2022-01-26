
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace challengePaggcerto.src.api.Models.EntityModel
{
    public static class AnticipationMap
    {
        public static void Map(this EntityTypeBuilder<Anticipation> entity)
        {
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }

}