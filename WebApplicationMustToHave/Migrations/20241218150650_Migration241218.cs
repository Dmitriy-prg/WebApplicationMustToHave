using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationMustToHave.Migrations
{
    /// <inheritdoc />
    public partial class Migration241218 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compositions_book_binders_DbCompositionTypeId",
                table: "compositions");

            migrationBuilder.CreateIndex(
                name: "IX_compositions_DbBookBinderId",
                table: "compositions",
                column: "DbBookBinderId",
                unique: true,
                filter: "[DbBookBinderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_book_binders_DbBookBinderId",
                table: "compositions",
                column: "DbBookBinderId",
                principalTable: "book_binders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compositions_book_binders_DbBookBinderId",
                table: "compositions");

            migrationBuilder.DropIndex(
                name: "IX_compositions_DbBookBinderId",
                table: "compositions");

            migrationBuilder.AddForeignKey(
                name: "FK_compositions_book_binders_DbCompositionTypeId",
                table: "compositions",
                column: "DbCompositionTypeId",
                principalTable: "book_binders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
