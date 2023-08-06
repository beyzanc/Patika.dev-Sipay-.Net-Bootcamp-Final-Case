using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class DbChangesv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "reciever_name",
                schema: "dbo",
                table: "Message",
                newName: "receiver_name");

            migrationBuilder.RenameColumn(
                name: "reciever_id",
                schema: "dbo",
                table: "Message",
                newName: "receiver_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "receiver_name",
                schema: "dbo",
                table: "Message",
                newName: "reciever_name");

            migrationBuilder.RenameColumn(
                name: "receiver_id",
                schema: "dbo",
                table: "Message",
                newName: "reciever_id");
        }
    }
}
