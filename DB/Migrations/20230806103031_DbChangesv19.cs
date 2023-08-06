using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class DbChangesv19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_User_payer_id",
                schema: "dbo",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "payer_id",
                schema: "dbo",
                table: "Bill",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_payer_id",
                schema: "dbo",
                table: "Bill",
                newName: "IX_Bill_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_User_user_id",
                schema: "dbo",
                table: "Bill",
                column: "user_id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_User_user_id",
                schema: "dbo",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "dbo",
                table: "Bill",
                newName: "payer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_user_id",
                schema: "dbo",
                table: "Bill",
                newName: "IX_Bill_payer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_User_payer_id",
                schema: "dbo",
                table: "Bill",
                column: "payer_id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "user_id");
        }
    }
}
