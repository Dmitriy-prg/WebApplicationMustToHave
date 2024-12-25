using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbRatingConfiguration : IEntityTypeConfiguration<DbRating>
    {
        public void Configure(EntityTypeBuilder<DbRating> builder)
        {
            builder.ToTable("ratings");
        }
    }
}
