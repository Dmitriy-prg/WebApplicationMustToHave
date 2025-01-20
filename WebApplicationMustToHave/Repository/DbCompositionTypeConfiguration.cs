using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbCompositionTypeConfiguration : IEntityTypeConfiguration<DbCompositionType>
    {
        public void Configure(EntityTypeBuilder<DbCompositionType> builder)
        {
            builder.ToTable("composition_types");
            builder.HasOne<DbComposition>().WithOne(c => c.Type).HasForeignKey<DbComposition>(c => c.DbCompositionTypeId);
        }
    }
}
