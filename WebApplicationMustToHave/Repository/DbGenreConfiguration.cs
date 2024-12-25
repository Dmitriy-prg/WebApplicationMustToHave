using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbGenreConfiguration : IEntityTypeConfiguration<DbGenre>
    {
        public void Configure(EntityTypeBuilder<DbGenre> builder)
        {
            builder.ToTable("genres");
        }
    }
}
