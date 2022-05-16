using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRepairShop.Api.Migrations
{
    public partial class initalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairShop",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Cnpj = table.Column<int>(type: "int", unicode: false, maxLength: 14, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairShop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", unicode: false, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRepairShop = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    ClientName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Type = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_RepairShop",
                        column: x => x.IdRepairShop,
                        principalTable: "RepairShop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_IdRepairShop",
                table: "Maintenance",
                column: "IdRepairShop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "RepairShop");
        }
    }
}
