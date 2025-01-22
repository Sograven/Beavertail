using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storge.Core.Migrations
{
    /// <inheritdoc />
    public partial class TryToFixTelegramId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TelegramID",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegramID",
                table: "Users");
        }
    }
}
