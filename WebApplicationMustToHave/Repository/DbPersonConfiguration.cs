using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbPersonConfiguration : IEntityTypeConfiguration<DbPerson>
    {
        public void Configure(EntityTypeBuilder<DbPerson> builder)
        {
            builder.ToTable("persons");
        }
    }
}
