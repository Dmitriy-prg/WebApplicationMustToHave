using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbMeasureUnitConfiguration : IEntityTypeConfiguration<DbMeasureUnit>
    {
        public void Configure(EntityTypeBuilder<DbMeasureUnit> builder)
        {
            builder.ToTable("measure_units");
            builder.HasOne<DbBitrate>().WithOne(b => b.Unit).HasForeignKey<DbBitrate>(b => b.DbMeasureUnitId);
            builder.HasOne<DbVolume>().WithOne(b => b.Unit).HasForeignKey<DbVolume>(b => b.DbMeasureUnitId);
        }
    }
}