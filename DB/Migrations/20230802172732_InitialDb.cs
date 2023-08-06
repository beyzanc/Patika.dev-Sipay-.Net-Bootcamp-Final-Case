using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Apartment",
                schema: "dbo",
                columns: table => new
                {
                    apartmen_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    block = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    floor = table.Column<int>(type: "integer", nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    own_status = table.Column<int>(type: "integer", nullable: false),
                    insert_date = table.Column<DateTime>(type: "date", nullable: false),
                    update_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.apartmen_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    surname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    identity_number = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    email = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    CarPlate = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    account_type = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    delete_status = table.Column<bool>(type: "boolean", nullable: false),
                    membership_date = table.Column<DateTime>(type: "date", nullable: false),
                    update_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                schema: "dbo",
                columns: table => new
                {
                    bill_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apartment_id = table.Column<int>(type: "integer", nullable: false),
                    payer_id = table.Column<int>(type: "integer", nullable: false),
                    bill_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    due_date = table.Column<DateTime>(type: "date", nullable: false),
                    payed_date = table.Column<DateTime>(type: "date", nullable: true),
                    month = table.Column<int>(type: "integer", maxLength: 30, nullable: false),
                    payment_status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    assign_date = table.Column<DateTime>(type: "date", nullable: false),
                    update_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.bill_id);
                    table.ForeignKey(
                        name: "FK_Bill_Apartment_apartment_id",
                        column: x => x.apartment_id,
                        principalSchema: "dbo",
                        principalTable: "Apartment",
                        principalColumn: "apartmen_id");
                    table.ForeignKey(
                        name: "FK_Bill_User_payer_id",
                        column: x => x.payer_id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "dbo",
                columns: table => new
                {
                    message_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subject = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    content = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_Message_User_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "UserApartments",
                schema: "dbo",
                columns: table => new
                {
                    ApartmentsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApartments", x => new { x.ApartmentsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserApartments_Apartment_ApartmentsId",
                        column: x => x.ApartmentsId,
                        principalSchema: "dbo",
                        principalTable: "Apartment",
                        principalColumn: "apartmen_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserApartments_User_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMessages",
                schema: "dbo",
                columns: table => new
                {
                    MessageRecieversId = table.Column<int>(type: "integer", nullable: false),
                    RecieversId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessages", x => new { x.MessageRecieversId, x.RecieversId });
                    table.ForeignKey(
                        name: "FK_UserMessages_Message_MessageRecieversId",
                        column: x => x.MessageRecieversId,
                        principalSchema: "dbo",
                        principalTable: "Message",
                        principalColumn: "message_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMessages_User_RecieversId",
                        column: x => x.RecieversId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_apartment_id",
                schema: "dbo",
                table: "Bill",
                column: "apartment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_payer_id",
                schema: "dbo",
                table: "Bill",
                column: "payer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                schema: "dbo",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_User_identity_number",
                schema: "dbo",
                table: "User",
                column: "identity_number");

            migrationBuilder.CreateIndex(
                name: "IX_UserApartments_UsersId",
                schema: "dbo",
                table: "UserApartments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_RecieversId",
                schema: "dbo",
                table: "UserMessages",
                column: "RecieversId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserApartments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserMessages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Apartment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
