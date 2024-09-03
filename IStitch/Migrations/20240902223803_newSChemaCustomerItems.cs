using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IStitch.Migrations
{
    /// <inheritdoc />
    public partial class newSChemaCustomerItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Service",
                newName: "ServiceName");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CusItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CusItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_CusItems_Service_ServiceName",
                        column: x => x.ServiceName,
                        principalTable: "Service",
                        principalColumn: "ServiceName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CusItems_ServiceName",
                table: "CusItems",
                column: "ServiceName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CusItems");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "Service",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
