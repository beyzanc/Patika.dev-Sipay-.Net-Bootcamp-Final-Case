using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class DbChangesv15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                schema: "dbo",
                table: "Message",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_ApartmentId",
                schema: "dbo",
                table: "Message",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Apartment_ApartmentId",
                schema: "dbo",
                table: "Message",
                column: "ApartmentId",
                principalSchema: "dbo",
                principalTable: "Apartment",
                principalColumn: "apartmen_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Apartment_ApartmentId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_ApartmentId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                schema: "dbo",
                table: "Message");
        }
    }
}
