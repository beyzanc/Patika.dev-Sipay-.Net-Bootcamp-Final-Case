using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class changes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 1,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7059), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7060) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 2,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7088), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7088) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 3,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7090), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7090) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 4,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7091), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7092) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 5,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7093), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7093) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 6,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7094), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7094) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 7,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7095), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7096) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 8,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7096), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7097) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 9,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7098), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7098) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 10,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7099), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(7099) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 1,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 30, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6979), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6978), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6979) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 2,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 23, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6984), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6984), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6984) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 3,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 17, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6986), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6985), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6986) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 4,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 28, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6989), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6988), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6988) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 5,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 17, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6990), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6989), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6990) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 6,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 13, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6992), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6991), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6991) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 7,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 27, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6993), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6993), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6993) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 8,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 12, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6995), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6994), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6995) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 9,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 19, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6996), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6996), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6996) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 1,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6918), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6919) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 2,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6921), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6921) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 3,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6922), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6923) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 4,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6923), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6924) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 5,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6924), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6925) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "membership_date", "password", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6501), "deneme", new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6510) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6523), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6523) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6652), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6652) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 4,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6675), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6676) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 5,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6718), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6719) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 6,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6738), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6738) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 7,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6755), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6756) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 8,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6773), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6773) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 9,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6814), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6814) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 10,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6832), new DateTime(2023, 8, 10, 4, 49, 20, 628, DateTimeKind.Local).AddTicks(6832) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 1,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4243), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4244) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 2,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4272), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4272) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 3,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4275), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4275) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 4,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4276), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4277) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 5,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4278), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4278) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 6,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4279), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4279) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 7,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4280), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4281) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 8,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4282), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4282) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 9,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4284), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Apartment",
                keyColumn: "apartment_id",
                keyValue: 10,
                columns: new[] { "insert_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4287), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4287) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 1,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 30, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4163), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4162), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4163) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 2,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 23, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4169), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4168), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4168) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 3,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 17, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4170), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4170), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4170) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 4,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 28, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4173), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4172), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4172) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 5,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 17, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4174), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4173), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4174) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 6,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 13, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4176), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4175), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4175) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 7,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 27, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4178), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4177), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4178) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 8,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 12, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4180), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4179), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4179) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bill",
                keyColumn: "bill_id",
                keyValue: 9,
                columns: new[] { "due_date", "assign_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 19, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4181), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4181), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4181) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 1,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4100), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4100) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 2,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4103), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4103) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 3,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4105), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4105) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 4,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4106), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4106) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Message",
                keyColumn: "message_id",
                keyValue: 5,
                columns: new[] { "received_date", "read_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4107), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4107) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "membership_date", "password", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3616), "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3623) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3810), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3811) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3836), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3836) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 4,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3856), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3857) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 5,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3901), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3902) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 6,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3922), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3923) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 7,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3940), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3940) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 8,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3957), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3958) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 9,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3998), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3999) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "user_id",
                keyValue: 10,
                columns: new[] { "membership_date", "update_date" },
                values: new object[] { new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4017), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4018) });
        }
    }
}
