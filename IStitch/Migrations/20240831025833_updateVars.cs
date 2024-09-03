using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IStitch.Migrations
{
    /// <inheritdoc />
    public partial class updateVars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sName",
                table: "AspNetUsers",
                newName: "lName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lName",
                table: "AspNetUsers",
                newName: "sName");
        }
    }
}
