using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storge.Core.Migrations
{
    /// <inheritdoc />
    public partial class TelegramIdIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_TelegramID",
                table: "Users",
                column: "TelegramID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_TelegramID",
                table: "Users");
        }
    }
}
