using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IStitch.Migrations
{
    /// <inheritdoc />
    public partial class itemslist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Service",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_UserId",
                table: "Service",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AspNetUsers_UserId",
                table: "Service",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_AspNetUsers_UserId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_UserId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Service");
        }
    }
}
