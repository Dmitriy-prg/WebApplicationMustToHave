using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbResolutionConfiguration : IEntityTypeConfiguration<DbResolution>
    {
        public void Configure(EntityTypeBuilder<DbResolution> builder)
        {
            builder.ToTable("resolutions");
            builder.HasOne<DbComposition>().WithOne(c => c.Resolution).HasForeignKey<DbComposition>(c => c.DbResolutionId);
        }
    }
}
