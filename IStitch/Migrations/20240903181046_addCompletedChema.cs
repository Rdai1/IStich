using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IStitch.Migrations
{
    /// <inheritdoc />
    public partial class addCompletedChema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "CusItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "CusItems");
        }
    }
}
