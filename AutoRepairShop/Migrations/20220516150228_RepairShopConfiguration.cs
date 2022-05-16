using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRepairShop.Api.Migrations
{
    public partial class RepairShopConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairShopConfiguration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRepairShop = table.Column<long>(type: "bigint", unicode: false, nullable: false),
                    WorkBalance = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairShopConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairShopConfiguration_RepairShop",
                        column: x => x.IdRepairShop,
                        principalTable: "RepairShop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairShopConfiguration_IdRepairShop",
                table: "RepairShopConfiguration",
                column: "IdRepairShop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairShopConfiguration");
        }
    }
}
