using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class DbBitrateConfiguration : IEntityTypeConfiguration<DbBitrate>
    {
        public void Configure(EntityTypeBuilder<DbBitrate> builder)
        {
            builder.ToTable("bitrates");
            builder.HasOne<DbComposition>().WithOne(c => c.BitrateVideo).HasForeignKey<DbComposition>(c => c.DbBitrateVideoId);
            builder.HasOne<DbComposition>().WithOne(c => c.BitrateAudio).HasForeignKey<DbComposition>(c => c.DbBitrateAudioId);
        }
    }
}
