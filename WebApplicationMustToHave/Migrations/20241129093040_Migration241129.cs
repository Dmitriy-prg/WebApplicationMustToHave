using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplicationMustToHave.Migrations
{
    /// <inheritdoc />
    public partial class Migration241129 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "book_binders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Жесткий" },
                    { 2L, "Мягкий" }
                });

            migrationBuilder.InsertData(
                table: "composition_types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Книга" },
                    { 2L, "Аудиокнига" },
                    { 3L, "Фильм" },
                    { 4L, "Песня" }
                });

            migrationBuilder.InsertData(
                table: "genre_types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Музыкальный" },
                    { 2L, "Литературный" },
                    { 3L, "Кино" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book_binders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "book_binders",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "composition_types",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "composition_types",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "composition_types",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "composition_types",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "genre_types",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "genre_types",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "genre_types",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
