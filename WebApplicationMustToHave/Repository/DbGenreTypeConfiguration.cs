using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbGenreTypeConfiguration : IEntityTypeConfiguration<DbGenreType>
    {
        public void Configure(EntityTypeBuilder<DbGenreType> builder)
        {
            builder.ToTable("genre_types");
            builder.HasOne<DbGenre>().WithOne(g => g.GenreType).HasForeignKey<DbGenre>(g => g.DbGenreTypeId);
        }
    }
}
