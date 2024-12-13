using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public class AppDbContext: DbContext
    {
        public DbSet<DbCompositionType> composition_types { get; set; } = null!;
        public DbSet<DbGenreType> genre_types { get; set; } = null!;
        public DbSet<DbBookBinder> book_binders { get; set; } = null!;
        public DbSet<DbGenre> genres { get; set; } = null!;
        public DbSet<DbMeasureUnit> measure_units { get; set; } = null!;
        public DbSet<DbBitrate> bitrates { get; set; } = null!;
        public DbSet<DbVolume> volumes { get; set; } = null!;
        public DbSet<DbRatingVersion> rating_versions { get; set; } = null!;
        public DbSet<DbRating> ratings { get; set; } = null!;        
        public DbSet<DbResolution> resolutions { get; set; } = null!;
        public DbSet<DbPublishing> publishers { get; set; } = null!;
        public DbSet<DbPublishing> compositions_persons_links { get; set; } = null!;
        public DbSet<DbComposition> compositions { get; set; } = null!;
        public DbSet<DbPerson> persons { get; set; } = null!;

        public AppDbContext() : base()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            ///*Add-Migration*/ InitialCreate   //Update-Database  //Remove-Migration
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("localdbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DbCompositionType>().ToTable("composition_types");
            
            modelBuilder.Entity<DbBookBinder>().ToTable("book_binders");
            
            modelBuilder.Entity<DbGenreType>().ToTable("genre_types");

            modelBuilder.Entity<DbGenre>().ToTable("genres");
            modelBuilder.Entity<DbGenreType>().HasOne<DbGenre>().WithOne(g => g.GenreType).HasForeignKey<DbGenre>(g => g.DbGenreTypeId);

            modelBuilder.Entity<DbMeasureUnit>().ToTable("measure_units");

            modelBuilder.Entity<DbBitrate>().ToTable("bitrates");
            modelBuilder.Entity<DbMeasureUnit>().HasOne<DbBitrate>().WithOne(b => b.Unit).HasForeignKey<DbBitrate>(b => b.DbMeasureUnitId);

            modelBuilder.Entity<DbVolume>().ToTable("volumes");
            modelBuilder.Entity<DbMeasureUnit>().HasOne<DbVolume>().WithOne(b => b.Unit).HasForeignKey<DbVolume>(b => b.DbMeasureUnitId);

            modelBuilder.Entity<DbRatingVersion>().ToTable("rating_versions");

            modelBuilder.Entity<DbRating>().ToTable("ratings");
            modelBuilder.Entity<DbRatingVersion>().HasOne<DbRating>().WithOne(b => b.Version).HasForeignKey<DbRating>(b => b.DbRatingVersionId);

            modelBuilder.Entity<DbResolution>().ToTable("resolutions");

            modelBuilder.Entity<DbPublishing>().ToTable("publishers");            

            modelBuilder.Entity<DbComposition>().ToTable("compositions");
            modelBuilder.Entity<DbCompositionType>().HasOne<DbComposition>().WithOne(c => c.Type).HasForeignKey<DbComposition>(c=>c.DbCompositionTypeId);
            modelBuilder.Entity<DbBookBinder>().HasOne<DbComposition>().WithOne(c => c.Binder).HasForeignKey<DbComposition>(c => c.DbCompositionTypeId);
            modelBuilder.Entity<DbVolume>().HasOne<DbComposition>().WithOne(c => c.Volume).HasForeignKey<DbComposition>(c => c.DbVolumeId);
            modelBuilder.Entity<DbPublishing>().HasOne<DbComposition>().WithOne(c => c.Publishing).HasForeignKey<DbComposition>(c => c.DbPublishingId);
            modelBuilder.Entity<DbBitrate>().HasOne<DbComposition>().WithOne(c => c.BitrateVideo).HasForeignKey<DbComposition>(c => c.DbBitrate_BitrateVideoId);
            modelBuilder.Entity<DbBitrate>().HasOne<DbComposition>().WithOne(c => c.BitrateAudio).HasForeignKey<DbComposition>(c => c.DbBitrate_BitrateAudioId);
            modelBuilder.Entity<DbResolution>().HasOne<DbComposition>().WithOne(c => c.Resolution).HasForeignKey<DbComposition>(c => c.DbResolutionId);
            
            modelBuilder.Entity<DbPerson>().ToTable("persons");
            modelBuilder.Entity<DbComposition>().HasMany(с => с.Authors).WithMany(p => p.DbComposition_Authors).UsingEntity("DbComposition_Authors_DbPerson");
            modelBuilder.Entity<DbComposition>().HasMany(с => с.Composers).WithMany(p => p.DbComposition_Composers).UsingEntity("DbComposition_Composers_DbPerson");
            modelBuilder.Entity<DbComposition>().HasMany(с => с.Directors).WithMany(p => p.DbComposition_Directors).UsingEntity("DbComposition_Directors_DbPerson");
            modelBuilder.Entity<DbComposition>().HasMany(с => с.Performers).WithMany(p => p.DbComposition_Performers).UsingEntity("DbComposition_Performers_DbPerson");

            //modelBuilder.Entity<DbCompositionDbPersonLink>().ToTable("compositions_persons_links");
            //modelBuilder.Entity<DbComposition>().HasMany(c => c.Authors).WithMany().UsingEntity<DbCompositionDbPersonLink>(
            //    c => c.HasOne(typeof(DbComposition)).WithMany().HasForeignKey(nameof(DbCompositionDbPersonLink.AuthorId)).HasPrincipalKey(nameof(DbComposition.Id)),
            //    p => p.HasOne(typeof(DbPerson)).WithMany().HasForeignKey(nameof(DbCompositionDbPersonLink.CompositionId)).HasPrincipalKey(nameof(DbPerson.Id)),
            //    cp => cp.HasKey(nameof(DbCompositionDbPersonLink.AuthorId), nameof(DbCompositionDbPersonLink.CompositionId)));
            //modelBuilder.Entity<DbComposition>().HasMany(c => c.Authors).WithMany().UsingEntity<DbCompositionDbPersonLink>(
            //    cp => cp.HasOne<DbComposition>().WithMany().HasForeignKey(c => c.AuthorId));
            //modelBuilder.Entity<DbPerson>().HasMany<DbComposition>().WithMany(c => c.Authors).UsingEntity<DbCompositionDbPersonLink>(
            //    cp => cp.HasOne<DbPerson>().WithMany().HasForeignKey(c => c.CompositionId));
            //modelBuilder.Entity<DbComposition>().HasMany(c => c.Composers).WithMany().UsingEntity<DbCompositionDbPersonLink>(
            //    cp => cp.HasOne<DbComposition>().WithMany().HasForeignKey(c => c.ComposerId));
            //modelBuilder.Entity<DbPerson>().HasMany<DbComposition>().WithMany(c => c.Composers).UsingEntity<DbCompositionDbPersonLink>(
            //    cp => cp.HasOne<DbPerson>().WithMany().HasForeignKey(c => c.CompositionId));
            //modelBuilder.Entity<DbComposition>().HasMany(c => c.Directors).WithMany().UsingEntity<DbCompositionDbPersonLink>(
            //    cp => cp.HasOne<DbComposition>().WithMany().HasForeignKey(c => c.DirectorId));
            //modelBuilder.Entity<DbPerson>().HasMany<DbComposition>().WithMany(c => c.Directors).UsingEntity<DbCompositionDbPersonLink>(
            //    cp => cp.HasOne<DbPerson>().WithMany().HasForeignKey(c => c.CompositionId));
            //modelBuilder.Entity<DbComposition>().HasMany(c => c.Performers).WithMany().UsingEntity<DbCompositionDbPersonLink>(
            //    cp => cp.HasOne<DbComposition>().WithMany().HasForeignKey(c => c.PerformerId));
            //modelBuilder.Entity<DbPerson>().HasMany<DbComposition>().WithMany(c => c.Performers).UsingEntity<DbCompositionDbPersonLink>(
            //    cp => cp.HasOne<DbPerson>().WithMany().HasForeignKey(c => c.CompositionId));

            modelBuilder.Entity<DbGenreType>().HasData(
                new DbGenreType { Id = 1, Name = "Музыкальный" },
                new DbGenreType { Id = 2, Name = "Литературный" },
                new DbGenreType { Id = 3, Name = "Кино" }
             );

            modelBuilder.Entity<DbBookBinder>().HasData(
                new DbBookBinder { Id = 1, Name = "Жесткий" },
                new DbBookBinder { Id = 2, Name = "Мягкий" }
            );

            modelBuilder.Entity<DbCompositionType>().HasData(
                new DbCompositionType { Id = 1, Name = "Книга" },
                new DbCompositionType { Id = 2, Name = "Аудиокнига" },
                new DbCompositionType { Id = 3, Name = "Фильм" },
                new DbCompositionType { Id = 4, Name = "Песня" }
            );
        }
    }
}
