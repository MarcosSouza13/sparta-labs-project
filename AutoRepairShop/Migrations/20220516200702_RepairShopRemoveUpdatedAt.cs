using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRepairShop.Api.Migrations
{
    public partial class RepairShopRemoveUpdatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RepairShop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RepairShop",
                type: "datetime",
                nullable: true);
        }
    }
}
