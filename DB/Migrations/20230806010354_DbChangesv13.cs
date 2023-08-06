using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class DbChangesv13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "dbo",
                table: "Message",
                newName: "read_date");

            migrationBuilder.RenameColumn(
                name: "insert_date",
                schema: "dbo",
                table: "Message",
                newName: "received_date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "received_date",
                schema: "dbo",
                table: "Message",
                newName: "insert_date");

            migrationBuilder.RenameColumn(
                name: "read_date",
                schema: "dbo",
                table: "Message",
                newName: "update_date");
        }
    }
}
