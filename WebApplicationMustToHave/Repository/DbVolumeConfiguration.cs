using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbVolumeConfiguration : IEntityTypeConfiguration<DbVolume>
    {
        public void Configure(EntityTypeBuilder<DbVolume> builder)
        {
            builder.ToTable("volumes");
            builder.HasOne<DbComposition>().WithOne(c => c.Volume).HasForeignKey<DbComposition>(c => c.DbVolumeId);
        }
    }
}
