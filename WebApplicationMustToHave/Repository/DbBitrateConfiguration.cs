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
            builder.HasOne<DbComposition>().WithOne(c => c.BitrateVideo).HasForeignKey<DbComposition>(c => c.DbBitrate_BitrateVideoId);
            builder.HasOne<DbComposition>().WithOne(c => c.BitrateAudio).HasForeignKey<DbComposition>(c => c.DbBitrate_BitrateAudioId);
        }
    }
}
