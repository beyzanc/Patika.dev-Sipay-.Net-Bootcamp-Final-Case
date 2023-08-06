using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class DbChangesv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                schema: "dbo",
                table: "Message",
                newName: "update_date");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Message",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                schema: "dbo",
                table: "Message",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "insert_date",
                schema: "dbo",
                table: "Message",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "receiver_surname",
                schema: "dbo",
                table: "Message",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_name",
                schema: "dbo",
                table: "Message",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sender_name",
                schema: "dbo",
                table: "Message",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sender_surname",
                schema: "dbo",
                table: "Message",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "insert_date",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "receiver_surname",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "reciever_name",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "sender_name",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "sender_surname",
                schema: "dbo",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "update_date",
                schema: "dbo",
                table: "Message",
                newName: "date");
        }
    }
}
