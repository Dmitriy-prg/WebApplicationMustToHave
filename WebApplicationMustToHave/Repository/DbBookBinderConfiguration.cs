using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbBookBinderConfiguration : IEntityTypeConfiguration<DbBookBinder>
    {
        public void Configure(EntityTypeBuilder<DbBookBinder> builder)
        {
            builder.ToTable("book_binders");
            builder.HasOne<DbComposition>().WithOne(c => c.Binder).HasForeignKey<DbComposition>(c => c.DbBookBinderId);
        }
    }
}
