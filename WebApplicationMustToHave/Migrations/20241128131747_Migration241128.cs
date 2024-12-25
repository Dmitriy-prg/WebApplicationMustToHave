using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationMustToHave.Migrations
{
    /// <inheritdoc />
    public partial class Migration241128 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bitrates_MeasureUnits_UnitId",
                table: "Bitrates");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Bitrates_BitrateAudioId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Bitrates_BitrateId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Bitrates_BitrateVideoId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Bitrates_DbSong_BitrateId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Persons_PerformerId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Publishers_DbAudioBook_PublishingId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Publishers_PublishingId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Resolutions_ResolutionId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Volumes_VolumeId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Compositions_DbCompositionId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Compositions_DbAudioBookId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Compositions_DbBookId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Compositions_DbFilmId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Compositions_DbFilmId1",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Compositions_DbSongId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Compositions_DbSongId1",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Compositions_DbSongId2",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Compositions_DbCompositionId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_RatingVersions_VersionId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_MeasureUnits_UnitId",
                table: "Volumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volumes",
                table: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Volumes_UnitId",
                table: "Volumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resolutions",
                table: "Resolutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_VersionId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DbAudioBookId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DbBookId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DbFilmId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DbFilmId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DbSongId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DbSongId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DbSongId2",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compositions",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_BitrateAudioId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_BitrateId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_BitrateVideoId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_DbAudioBook_PublishingId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_DbSong_BitrateId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_PerformerId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_PublishingId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_ResolutionId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_VolumeId",
                table: "Compositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bitrates",
                table: "Bitrates");

            migrationBuilder.DropIndex(
                name: "IX_Bitrates_UnitId",
                table: "Bitrates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingVersions",
                table: "RatingVersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasureUnits",
                table: "MeasureUnits");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Volumes");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "DbAudioBookId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DbBookId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DbFilmId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DbFilmId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DbSongId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DbSongId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DbSongId2",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "GenreType",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Binder",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "BitrateAudioId",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "BitrateId",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "BitrateVideoId",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Bitrates");

            migrationBuilder.RenameTable(
                name: "Volumes",
                newName: "volumes");

            migrationBuilder.RenameTable(
                name: "Resolutions",
                newName: "resolutions");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "ratings");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "publishers");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "persons");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "genres");

            migrationBuilder.RenameTable(
                name: "Compositions",
                newName: "compositions");

            migrationBuilder.RenameTable(
                name: "Bitrates",
                newName: "bitrates");

            migrationBuilder.RenameTable(
                name: "RatingVersions",
                newName: "rating_versions");

            migrationBuilder.RenameTable(
                name: "MeasureUnits",
                newName: "measure_units");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_DbCompositionId",
                table: "ratings",
                newName: "IX_ratings_DbCompositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Genres_DbCompositionId",
                table: "genres",
                newName: "IX_genres_DbCompositionId");

            migrationBuilder.RenameColumn(
                name: "VolumeId",
                table: "compositions",
                newName: "DbVolumeId");

            migrationBuilder.RenameColumn(
                name: "ResolutionId",
                table: "compositions",
                newName: "DbResolutionId");

            migrationBuilder.RenameColumn(
                name: "PublishingId",
                table: "compositions",
                newName: "DbPublishingId");

            migrationBuilder.RenameColumn(
                name: "PerformerId",
                table: "compositions",
                newName: "DbBookBinderId");

            migrationBuilder.RenameColumn(
                name: "DbSong_BitrateId",
                table: "compositions",
                newName: "DbBitrate_BitrateVideoId");

            migrationBuilder.RenameColumn(
                name: "DbAudioBook_PublishingId",
                table: "compositions",
                newName: "DbBitrate_BitrateAudioId");

            migrationBuilder.AddColumn<long>(
                name: "DbMeasureUnitId",
                table: "volumes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DbRatingVersionId",
                table: "ratings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DbGenreTypeId",
                table: "genres",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DbCompositionTypeId",
                table: "compositions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DbMeasureUnitId",
                table: "bitrates",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_volumes",
                table: "volumes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_resolutions",
                table: "resolutions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ratings",
                table: "ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_publishers",
                table: "publishers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_persons",
                table: "persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genres",
                table: "genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_compositions",
                table: "compositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bitrates",
                table: "bitrates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rating_versions",
                table: "rating_versions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_measure_units",
                table: "measure_units",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "book_binders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_binders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "composition_types",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_composition_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbComposition_Authors_DbPerson",
                columns: table => new
                {
                    AuthorsId = table.Column<long>(type: "bigint", nullable: false),
                    DbComposition_AuthorsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbComposition_Authors_DbPerson", x => new { x.AuthorsId, x.DbComposition_AuthorsId });
                    table.ForeignKey(
                        name: "FK_DbComposition_Authors_DbPerson_compositions_DbComposition_AuthorsId",
                        column: x => x.DbComposition_AuthorsId,
                        principalTable: "compositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbComposition_Authors_DbPerson_persons_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbComposition_Composers_DbPerson",
                columns: table => new
                {
                    ComposersId = table.Column<long>(type: "bigint", nullable: false),
                    DbComposition_ComposersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbComposition_Composers_DbPerson", x => new { x.ComposersId, x.DbComposition_ComposersId });
                    table.ForeignKey(
                        name: "FK_DbComposition_Composers_DbPerson_compositions_DbComposition_ComposersId",
                        column: x => x.DbComposition_ComposersId,
                        principalTable: "compositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbComposition_Composers_DbPerson_persons_ComposersId",
                        column: x => x.ComposersId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbComposition_Directors_DbPerson",
                columns: table => new
                {
                    DbComposition_DirectorsId = table.Column<long>(type: "bigint", nullable: false),
                    DirectorsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbComposition_Directors_DbPerson", x => new { x.DbComposition_DirectorsId, x.DirectorsId });
                    table.ForeignKey(
                        name: "FK_DbComposition_Directors_DbPerson_compositions_DbComposition_DirectorsId",
                        column: x => x.DbComposition_DirectorsId,
                        principalTable: "compositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbComposition_Directors_DbPerson_persons_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbComposition_Performers_DbPerson",
                columns: table => new
                {
                    DbComposition_PerformersId = table.Column<long>(type: "bigint", nullable: false),
                    PerformersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbComposition_Performers_DbPerson", x => new { x.DbComposition_PerformersId, x.PerformersId });
                    table.ForeignKey(
                        name: "FK_DbComposition_Performers_DbPerson_compositions_DbComposition_PerformersId",
                        column: x => x.DbComposition_PerformersId,
                        principalTable: "compositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbComposition_Performers_DbPerson_persons_PerformersId",
                        column: x => x.PerformersId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "genre_types",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre_types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_volumes_DbMeasureUnitId",
                table: "volumes",
                column: "DbMeasureUnitId",
                unique: true,
                filter: "[DbMeasureUnitId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_DbRatingVersionId",
                table: "ratings",
                column: "DbRatingVersionId",
                unique: true,
                filter: "[DbRatingVersionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_genres_DbGenreTypeId",
                table: "genres",
                column: "DbGenreTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_compositions_DbBitrate_BitrateAudioId",
                table: "compositions",
                column: "DbBitrate_BitrateAudioId",
                unique: true,
                filter: "[DbBitrate_BitrateAudioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_compositions_DbBitrate_BitrateVideoId",
                table: "compositions",
                column: "DbBitrate_BitrateVideoId",
                unique: true,
                filter: "[DbBitrate_BitrateVideoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_compositions_DbCompositionTypeId",
                table: "compositions",
                column: "DbCompositionTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_compositions_DbPublishingId",
                table: "compositions",
                column: "DbPublishingId",
                unique: true,
                filter: "[DbPublishingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_compositions_DbResolutionId",
                table: "compositions",
                column: "DbResolutionId",
                unique: true,
                filter: "[DbResolutionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_compositions_DbVolumeId",
                table: "compositions",
                column: "DbVolumeId",
                unique: true,
                filter: "[DbVolumeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_bitrates_DbMeasureUnitId",
                table: "bitrates",
                column: "DbMeasureUnitId",
                unique: true,
                filter: "[DbMeasureUnitId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DbComposition_Authors_DbPerson_DbComposition_AuthorsId",
                table: "DbComposition_Authors_DbPerson",
                column: "DbComposition_AuthorsId");

            migrationBuilder.CreateIndex(
                name: "IX_DbComposition_Composers_DbPerson_DbComposition_ComposersId",
                table: "DbComposition_Composers_DbPerson",
                column: "DbComposition_ComposersId");

            migrationBuilder.CreateIndex(
                name: "IX_DbComposition_Directors_DbPerson_DirectorsId",
                table: "DbComposition_Directors_DbPerson",
                column: "DirectorsId");

            migrationBuilder.CreateIndex(
                name: "IX_DbComposition_Performers_DbPerson_PerformersId",
                table: "DbComposition_Performers_DbPerson",
                column: "PerformersId");

            migrationBuilder.AddForeignKey(
                name: "FK_bitrates_measure_units_DbMeasureUnitId",
                table: "bitrates",
                column: "DbMeasureUnitId",
                principalTable: "measure_units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_bitrates_DbBitrate_BitrateAudioId",
                table: "compositions",
                column: "DbBitrate_BitrateAudioId",
                principalTable: "bitrates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_bitrates_DbBitrate_BitrateVideoId",
                table: "compositions",
                column: "DbBitrate_BitrateVideoId",
                principalTable: "bitrates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_book_binders_DbCompositionTypeId",
                table: "compositions",
                column: "DbCompositionTypeId",
                principalTable: "book_binders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_composition_types_DbCompositionTypeId",
                table: "compositions",
                column: "DbCompositionTypeId",
                principalTable: "composition_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_publishers_DbPublishingId",
                table: "compositions",
                column: "DbPublishingId",
                principalTable: "publishers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_resolutions_DbResolutionId",
                table: "compositions",
                column: "DbResolutionId",
                principalTable: "resolutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_volumes_DbVolumeId",
                table: "compositions",
                column: "DbVolumeId",
                principalTable: "volumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_genres_compositions_DbCompositionId",
                table: "genres",
                column: "DbCompositionId",
                principalTable: "compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_genres_genre_types_DbGenreTypeId",
                table: "genres",
                column: "DbGenreTypeId",
                principalTable: "genre_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_compositions_DbCompositionId",
                table: "ratings",
                column: "DbCompositionId",
                principalTable: "compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_rating_versions_DbRatingVersionId",
                table: "ratings",
                column: "DbRatingVersionId",
                principalTable: "rating_versions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_volumes_measure_units_DbMeasureUnitId",
                table: "volumes",
                column: "DbMeasureUnitId",
                principalTable: "measure_units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bitrates_measure_units_DbMeasureUnitId",
                table: "bitrates");

            migrationBuilder.DropForeignKey(
                name: "FK_compositions_bitrates_DbBitrate_BitrateAudioId",
                table: "compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_compositions_bitrates_DbBitrate_BitrateVideoId",
                table: "compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_compositions_book_binders_DbCompositionTypeId",
                table: "compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_compositions_composition_types_DbCompositionTypeId",
                table: "compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_compositions_publishers_DbPublishingId",
                table: "compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_compositions_resolutions_DbResolutionId",
                table: "compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_compositions_volumes_DbVolumeId",
                table: "compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_genres_compositions_DbCompositionId",
                table: "genres");

            migrationBuilder.DropForeignKey(
                name: "FK_genres_genre_types_DbGenreTypeId",
                table: "genres");

            migrationBuilder.DropForeignKey(
                name: "FK_ratings_compositions_DbCompositionId",
                table: "ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ratings_rating_versions_DbRatingVersionId",
                table: "ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_volumes_measure_units_DbMeasureUnitId",
                table: "volumes");

            migrationBuilder.DropTable(
                name: "book_binders");

            migrationBuilder.DropTable(
                name: "composition_types");

            migrationBuilder.DropTable(
                name: "DbComposition_Authors_DbPerson");

            migrationBuilder.DropTable(
                name: "DbComposition_Composers_DbPerson");

            migrationBuilder.DropTable(
                name: "DbComposition_Directors_DbPerson");

            migrationBuilder.DropTable(
                name: "DbComposition_Performers_DbPerson");

            migrationBuilder.DropTable(
                name: "genre_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_volumes",
                table: "volumes");

            migrationBuilder.DropIndex(
                name: "IX_volumes_DbMeasureUnitId",
                table: "volumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_resolutions",
                table: "resolutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ratings",
                table: "ratings");

            migrationBuilder.DropIndex(
                name: "IX_ratings_DbRatingVersionId",
                table: "ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_publishers",
                table: "publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_persons",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genres",
                table: "genres");

            migrationBuilder.DropIndex(
                name: "IX_genres_DbGenreTypeId",
                table: "genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_compositions",
                table: "compositions");

            migrationBuilder.DropIndex(
                name: "IX_compositions_DbBitrate_BitrateAudioId",
                table: "compositions");

            migrationBuilder.DropIndex(
                name: "IX_compositions_DbBitrate_BitrateVideoId",
                table: "compositions");

            migrationBuilder.DropIndex(
                name: "IX_compositions_DbCompositionTypeId",
                table: "compositions");

            migrationBuilder.DropIndex(
                name: "IX_compositions_DbPublishingId",
                table: "compositions");

            migrationBuilder.DropIndex(
                name: "IX_compositions_DbResolutionId",
                table: "compositions");

            migrationBuilder.DropIndex(
                name: "IX_compositions_DbVolumeId",
                table: "compositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bitrates",
                table: "bitrates");

            migrationBuilder.DropIndex(
                name: "IX_bitrates_DbMeasureUnitId",
                table: "bitrates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rating_versions",
                table: "rating_versions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_measure_units",
                table: "measure_units");

            migrationBuilder.DropColumn(
                name: "DbMeasureUnitId",
                table: "volumes");

            migrationBuilder.DropColumn(
                name: "DbRatingVersionId",
                table: "ratings");

            migrationBuilder.DropColumn(
                name: "DbGenreTypeId",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "DbCompositionTypeId",
                table: "compositions");

            migrationBuilder.DropColumn(
                name: "DbMeasureUnitId",
                table: "bitrates");

            migrationBuilder.RenameTable(
                name: "volumes",
                newName: "Volumes");

            migrationBuilder.RenameTable(
                name: "resolutions",
                newName: "Resolutions");

            migrationBuilder.RenameTable(
                name: "ratings",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "publishers",
                newName: "Publishers");

            migrationBuilder.RenameTable(
                name: "persons",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "compositions",
                newName: "Compositions");

            migrationBuilder.RenameTable(
                name: "bitrates",
                newName: "Bitrates");

            migrationBuilder.RenameTable(
                name: "rating_versions",
                newName: "RatingVersions");

            migrationBuilder.RenameTable(
                name: "measure_units",
                newName: "MeasureUnits");

            migrationBuilder.RenameIndex(
                name: "IX_ratings_DbCompositionId",
                table: "Ratings",
                newName: "IX_Ratings_DbCompositionId");

            migrationBuilder.RenameIndex(
                name: "IX_genres_DbCompositionId",
                table: "Genres",
                newName: "IX_Genres_DbCompositionId");

            migrationBuilder.RenameColumn(
                name: "DbVolumeId",
                table: "Compositions",
                newName: "VolumeId");

            migrationBuilder.RenameColumn(
                name: "DbResolutionId",
                table: "Compositions",
                newName: "ResolutionId");

            migrationBuilder.RenameColumn(
                name: "DbPublishingId",
                table: "Compositions",
                newName: "PublishingId");

            migrationBuilder.RenameColumn(
                name: "DbBookBinderId",
                table: "Compositions",
                newName: "PerformerId");

            migrationBuilder.RenameColumn(
                name: "DbBitrate_BitrateVideoId",
                table: "Compositions",
                newName: "DbSong_BitrateId");

            migrationBuilder.RenameColumn(
                name: "DbBitrate_BitrateAudioId",
                table: "Compositions",
                newName: "DbAudioBook_PublishingId");

            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "Volumes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VersionId",
                table: "Ratings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DbAudioBookId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DbBookId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DbFilmId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DbFilmId1",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DbSongId",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DbSongId1",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DbSongId2",
                table: "Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreType",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Binder",
                table: "Compositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BitrateAudioId",
                table: "Compositions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BitrateId",
                table: "Compositions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BitrateVideoId",
                table: "Compositions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Compositions",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "Bitrates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volumes",
                table: "Volumes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resolutions",
                table: "Resolutions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compositions",
                table: "Compositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bitrates",
                table: "Bitrates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingVersions",
                table: "RatingVersions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasureUnits",
                table: "MeasureUnits",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_UnitId",
                table: "Volumes",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VersionId",
                table: "Ratings",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DbAudioBookId",
                table: "Persons",
                column: "DbAudioBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DbBookId",
                table: "Persons",
                column: "DbBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DbFilmId",
                table: "Persons",
                column: "DbFilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DbFilmId1",
                table: "Persons",
                column: "DbFilmId1");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DbSongId",
                table: "Persons",
                column: "DbSongId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DbSongId1",
                table: "Persons",
                column: "DbSongId1");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DbSongId2",
                table: "Persons",
                column: "DbSongId2");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_BitrateAudioId",
                table: "Compositions",
                column: "BitrateAudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_BitrateId",
                table: "Compositions",
                column: "BitrateId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_BitrateVideoId",
                table: "Compositions",
                column: "BitrateVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_DbAudioBook_PublishingId",
                table: "Compositions",
                column: "DbAudioBook_PublishingId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_DbSong_BitrateId",
                table: "Compositions",
                column: "DbSong_BitrateId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_PerformerId",
                table: "Compositions",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_PublishingId",
                table: "Compositions",
                column: "PublishingId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_ResolutionId",
                table: "Compositions",
                column: "ResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_VolumeId",
                table: "Compositions",
                column: "VolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitrates_UnitId",
                table: "Bitrates",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bitrates_MeasureUnits_UnitId",
                table: "Bitrates",
                column: "UnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Bitrates_BitrateAudioId",
                table: "Compositions",
                column: "BitrateAudioId",
                principalTable: "Bitrates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Bitrates_BitrateId",
                table: "Compositions",
                column: "BitrateId",
                principalTable: "Bitrates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Bitrates_BitrateVideoId",
                table: "Compositions",
                column: "BitrateVideoId",
                principalTable: "Bitrates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Bitrates_DbSong_BitrateId",
                table: "Compositions",
                column: "DbSong_BitrateId",
                principalTable: "Bitrates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Persons_PerformerId",
                table: "Compositions",
                column: "PerformerId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Publishers_DbAudioBook_PublishingId",
                table: "Compositions",
                column: "DbAudioBook_PublishingId",
                principalTable: "Publishers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Publishers_PublishingId",
                table: "Compositions",
                column: "PublishingId",
                principalTable: "Publishers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Resolutions_ResolutionId",
                table: "Compositions",
                column: "ResolutionId",
                principalTable: "Resolutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Volumes_VolumeId",
                table: "Compositions",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Compositions_DbCompositionId",
                table: "Genres",
                column: "DbCompositionId",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Compositions_DbAudioBookId",
                table: "Persons",
                column: "DbAudioBookId",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Compositions_DbBookId",
                table: "Persons",
                column: "DbBookId",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Compositions_DbFilmId",
                table: "Persons",
                column: "DbFilmId",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Compositions_DbFilmId1",
                table: "Persons",
                column: "DbFilmId1",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Compositions_DbSongId",
                table: "Persons",
                column: "DbSongId",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Compositions_DbSongId1",
                table: "Persons",
                column: "DbSongId1",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Compositions_DbSongId2",
                table: "Persons",
                column: "DbSongId2",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Compositions_DbCompositionId",
                table: "Ratings",
                column: "DbCompositionId",
                principalTable: "Compositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_RatingVersions_VersionId",
                table: "Ratings",
                column: "VersionId",
                principalTable: "RatingVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_MeasureUnits_UnitId",
                table: "Volumes",
                column: "UnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
