using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationMustToHave.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasureUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resolutions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<long>(type: "bigint", nullable: false),
                    Width = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bitrates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitrates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bitrates_MeasureUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasureUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volumes_MeasureUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasureUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compositions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearBirth = table.Column<long>(type: "bigint", nullable: true),
                    VolumeId = table.Column<long>(type: "bigint", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PerformerId = table.Column<long>(type: "bigint", nullable: true),
                    DbAudioBook_PublishingId = table.Column<long>(type: "bigint", nullable: true),
                    BitrateId = table.Column<long>(type: "bigint", nullable: true),
                    PublishingId = table.Column<long>(type: "bigint", nullable: true),
                    Binder = table.Column<int>(type: "int", nullable: true),
                    Density = table.Column<long>(type: "bigint", nullable: true),
                    BitrateAudioId = table.Column<long>(type: "bigint", nullable: true),
                    BitrateVideoId = table.Column<long>(type: "bigint", nullable: true),
                    ResolutionId = table.Column<long>(type: "bigint", nullable: true),
                    DbSong_BitrateId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compositions_Bitrates_BitrateAudioId",
                        column: x => x.BitrateAudioId,
                        principalTable: "Bitrates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Bitrates_BitrateId",
                        column: x => x.BitrateId,
                        principalTable: "Bitrates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Bitrates_BitrateVideoId",
                        column: x => x.BitrateVideoId,
                        principalTable: "Bitrates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Bitrates_DbSong_BitrateId",
                        column: x => x.DbSong_BitrateId,
                        principalTable: "Bitrates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Publishers_DbAudioBook_PublishingId",
                        column: x => x.DbAudioBook_PublishingId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Publishers_PublishingId",
                        column: x => x.PublishingId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Resolutions_ResolutionId",
                        column: x => x.ResolutionId,
                        principalTable: "Resolutions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Volumes_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volumes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DbCompositionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Compositions_DbCompositionId",
                        column: x => x.DbCompositionId,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearBirth = table.Column<long>(type: "bigint", nullable: true),
                    DbAudioBookId = table.Column<long>(type: "bigint", nullable: true),
                    DbBookId = table.Column<long>(type: "bigint", nullable: true),
                    DbFilmId = table.Column<long>(type: "bigint", nullable: true),
                    DbFilmId1 = table.Column<long>(type: "bigint", nullable: true),
                    DbSongId = table.Column<long>(type: "bigint", nullable: true),
                    DbSongId1 = table.Column<long>(type: "bigint", nullable: true),
                    DbSongId2 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Compositions_DbAudioBookId",
                        column: x => x.DbAudioBookId,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Compositions_DbBookId",
                        column: x => x.DbBookId,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Compositions_DbFilmId",
                        column: x => x.DbFilmId,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Compositions_DbFilmId1",
                        column: x => x.DbFilmId1,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Compositions_DbSongId",
                        column: x => x.DbSongId,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Compositions_DbSongId1",
                        column: x => x.DbSongId1,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Compositions_DbSongId2",
                        column: x => x.DbSongId2,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    DbCompositionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Compositions_DbCompositionId",
                        column: x => x.DbCompositionId,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_RatingVersions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "RatingVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitrates_UnitId",
                table: "Bitrates",
                column: "UnitId");

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
                name: "IX_Genres_DbCompositionId",
                table: "Genres",
                column: "DbCompositionId");

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
                name: "IX_Ratings_DbCompositionId",
                table: "Ratings",
                column: "DbCompositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VersionId",
                table: "Ratings",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_UnitId",
                table: "Volumes",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Persons_PerformerId",
                table: "Compositions",
                column: "PerformerId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bitrates_MeasureUnits_UnitId",
                table: "Bitrates");

            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_MeasureUnits_UnitId",
                table: "Volumes");

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

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "RatingVersions");

            migrationBuilder.DropTable(
                name: "MeasureUnits");

            migrationBuilder.DropTable(
                name: "Bitrates");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Compositions");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Resolutions");

            migrationBuilder.DropTable(
                name: "Volumes");
        }
    }
}
