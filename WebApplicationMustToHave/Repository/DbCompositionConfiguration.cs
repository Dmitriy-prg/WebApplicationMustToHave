using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbCompositionConfiguration : IEntityTypeConfiguration<DbComposition>
    {
        public void Configure(EntityTypeBuilder<DbComposition> builder)
        {
            builder.ToTable("compositions");
            builder.HasMany(с => с.Authors).WithMany(p => p.DbCompositionsOfAuthor).UsingEntity("DbComposition_Authors_DbPerson");
            builder.HasMany(с => с.Composers).WithMany(p => p.DbCompositionOfComposer).UsingEntity("DbComposition_Composers_DbPerson");
            builder.HasMany(с => с.Directors).WithMany(p => p.DbCompositionOfDirector).UsingEntity("DbComposition_Directors_DbPerson");
            builder.HasMany(с => с.Performers).WithMany(p => p.DbCompositionOfPerformer).UsingEntity("DbComposition_Performers_DbPerson");
        }
    }
}
