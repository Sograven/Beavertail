using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storge.Core.Migrations.AllOrders
{
    /// <inheritdoc />
    public partial class FixError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Position",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Position_OrderId",
                table: "Position",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Position_OrderId",
                table: "Position");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Position",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                columns: new[] { "OrderId", "Id" });
        }
    }
}
