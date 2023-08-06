using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class DbChangesv8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_SenderId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                schema: "dbo",
                table: "Message",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "Message",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserId",
                schema: "dbo",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_SenderId",
                schema: "dbo",
                table: "Message",
                column: "SenderId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
