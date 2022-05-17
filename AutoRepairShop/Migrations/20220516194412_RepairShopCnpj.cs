using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoRepairShop.Api.Migrations
{
    public partial class RepairShopCnpj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdRepairShop",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "RepairShop",
                type: "varchar(14)",
                unicode: false,
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldMaxLength: 14);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRepairShop",
                table: "User",
                column: "IdRepairShop");

            migrationBuilder.AddForeignKey(
                name: "FK_User_RepairShop",
                table: "User",
                column: "IdRepairShop",
                principalTable: "RepairShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_RepairShop",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdRepairShop",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdRepairShop",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "Cnpj",
                table: "RepairShop",
                type: "int",
                unicode: false,
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false,
                oldMaxLength: 14);
        }
    }
}
