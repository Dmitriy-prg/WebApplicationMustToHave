using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using WebApplicationMustToHave.DataModels;

namespace WebApplicationMustToHave.Repository
{
    public interface IAppDbContext
    {
        public DbSet<DbCompositionType> CompositionTypes { get; set; }
        public DbSet<DbGenreType> GenreTypes { get; set; }
        public DbSet<DbBookBinder> BookBinders { get; set; }
        public DbSet<DbGenre> Genres { get; set; }
        public DbSet<DbMeasureUnit> MeasureUnits { get; set; }
        public DbSet<DbBitrate> Bitrates { get; set; }
        public DbSet<DbVolume> Volumes { get; set; }
        public DbSet<DbRatingVersion> RatingVersions { get; set; }
        public DbSet<DbRating> Ratings { get; set; }
        public DbSet<DbResolution> Resolutions { get; set; }
        public DbSet<DbPublishing> Publishers { get; set; }
        public DbSet<DbPublishing> CompositionsPersonsLinks { get; set; }
        public DbSet<DbComposition> Compositions { get; set; }
        public DbSet<DbPerson> Persons { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }


        public class AppDbContext: DbContext, IAppDbContext
    {
        public DbSet<DbCompositionType> CompositionTypes { get; set; } = null!;
        public DbSet<DbGenreType> GenreTypes { get; set; } = null!;
        public DbSet<DbBookBinder> BookBinders { get; set; } = null!;
        public DbSet<DbGenre> Genres { get; set; } = null!;
        public DbSet<DbMeasureUnit> MeasureUnits { get; set; } = null!;
        public DbSet<DbBitrate> Bitrates { get; set; } = null!;
        public DbSet<DbVolume> Volumes { get; set; } = null!;
        public DbSet<DbRatingVersion> RatingVersions { get; set; } = null!;
        public DbSet<DbRating> Ratings { get; set; } = null!;        
        public DbSet<DbResolution> Resolutions { get; set; } = null!;
        public DbSet<DbPublishing> Publishers { get; set; } = null!;
        public DbSet<DbPublishing> CompositionsPersonsLinks { get; set; } = null!;
        public DbSet<DbComposition> Compositions { get; set; } = null!;
        public DbSet<DbPerson> Persons { get; set; } = null!;

        public AppDbContext() : base()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            ///*Add-Migration*/ InitialCreate   //Update-Database  //Remove-Migration
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
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

            modelBuilder.ApplyConfiguration(new DbCompositionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DbBookBinderConfiguration());
            modelBuilder.ApplyConfiguration(new DbGenreTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DbGenreConfiguration());
            modelBuilder.ApplyConfiguration(new DbMeasureUnitConfiguration());
            modelBuilder.ApplyConfiguration(new DbBitrateConfiguration());
            modelBuilder.ApplyConfiguration(new DbVolumeConfiguration());
            modelBuilder.ApplyConfiguration(new DbRatingVersionConfiguration());
            modelBuilder.ApplyConfiguration(new DbRatingConfiguration());
            modelBuilder.ApplyConfiguration(new DbResolutionConfiguration());
            modelBuilder.ApplyConfiguration(new DbPublishingConfiguration());
            modelBuilder.ApplyConfiguration(new DbCompositionConfiguration());
            modelBuilder.ApplyConfiguration(new DbPersonConfiguration());

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
