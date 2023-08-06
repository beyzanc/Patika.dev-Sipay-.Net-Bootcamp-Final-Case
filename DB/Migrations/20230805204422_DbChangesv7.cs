using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class DbChangesv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "own_status",
                schema: "dbo",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "dbo",
                table: "Apartment");

            migrationBuilder.AddColumn<bool>(
                name: "is_full",
                schema: "dbo",
                table: "Apartment",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_rented",
                schema: "dbo",
                table: "Apartment",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_full",
                schema: "dbo",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "is_rented",
                schema: "dbo",
                table: "Apartment");

            migrationBuilder.AddColumn<int>(
                name: "own_status",
                schema: "dbo",
                table: "Apartment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "dbo",
                table: "Apartment",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
