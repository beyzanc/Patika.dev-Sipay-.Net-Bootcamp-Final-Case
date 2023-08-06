using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class DbChangesv9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "Message",
                newName: "sender_id");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                schema: "dbo",
                table: "Message",
                newName: "reciever_id");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserId",
                schema: "dbo",
                table: "Message",
                newName: "IX_Message_sender_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_sender_id",
                schema: "dbo",
                table: "Message",
                column: "sender_id",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_sender_id",
                schema: "dbo",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "sender_id",
                schema: "dbo",
                table: "Message",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "reciever_id",
                schema: "dbo",
                table: "Message",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_sender_id",
                schema: "dbo",
                table: "Message",
                newName: "IX_Message_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_UserId",
                schema: "dbo",
                table: "Message",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
