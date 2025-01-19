using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storge.Core.Migrations
{
    /// <inheritdoc />
    public partial class UserID_IsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID",
                table: "Users",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserID",
                table: "Users");
        }
    }
}
