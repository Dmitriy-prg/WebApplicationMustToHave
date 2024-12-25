using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbRatingVersionConfiguration : IEntityTypeConfiguration<DbRatingVersion>
    {
        public void Configure(EntityTypeBuilder<DbRatingVersion> builder)
        {
            builder.ToTable("rating_versions");
            builder.HasOne<DbRating>().WithOne(b => b.Version).HasForeignKey<DbRating>(b => b.DbRatingVersionId);
        }
    }
}
