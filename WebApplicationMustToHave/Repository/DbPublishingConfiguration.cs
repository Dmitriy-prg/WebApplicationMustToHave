using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbPublishingConfiguration : IEntityTypeConfiguration<DbPublishing>
    {
        public void Configure(EntityTypeBuilder<DbPublishing> builder)
        {
            builder.ToTable("publishers");
            builder.HasOne<DbComposition>().WithOne(c => c.Publishing).HasForeignKey<DbComposition>(c => c.DbPublishingId);
        }
    }
}
