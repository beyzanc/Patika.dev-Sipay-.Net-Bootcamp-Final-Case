using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ResiPay.DB.Migrations
{
    public partial class changes : Migration
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
                    apartment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    block = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    floor = table.Column<int>(type: "integer", nullable: false),
                    no = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(20)", nullable: false),
                    is_full = table.Column<bool>(type: "boolean", nullable: false),
                    is_rented = table.Column<bool>(type: "boolean", nullable: false),
                    insert_date = table.Column<DateTime>(type: "date", nullable: false),
                    update_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.apartment_id);
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
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    CarPlate = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    delete_status = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    apartment_id = table.Column<int>(type: "integer", nullable: false),
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
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    due_date = table.Column<DateTime>(type: "date", nullable: false),
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
                        principalColumn: "apartment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CardNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    CVC = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Date = table.Column<string>(type: "text", nullable: true),
                    ApartmentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
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
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    receiver_id = table.Column<int>(type: "integer", nullable: false),
                    is_read = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    receiver_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    receiver_surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    sender_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    sender_surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    received_date = table.Column<DateTime>(type: "date", nullable: false),
                    read_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_Message_User_sender_id",
                        column: x => x.sender_id,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "apartment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserApartments_User_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Apartment",
                columns: new[] { "apartment_id", "block", "floor", "no", "type", "insert_date", "is_full", "is_rented", "update_date" },
                values: new object[,]
                {
                    { 1, "A", 4, 44, "2+1", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4243), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4244) },
                    { 2, "B", 3, 34, "1+1", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4272), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4272) },
                    { 3, "C", 5, 65, "3+1", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4275), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4275) },
                    { 4, "B", 5, 63, "2+1", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4276), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4277) },
                    { 5, "D", 7, 87, "1+0", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4278), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4278) },
                    { 6, "G", 13, 144, "3+0", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4279), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4279) },
                    { 7, "E", 6, 78, "1+0", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4280), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4281) },
                    { 8, "D", 3, 33, "1+1", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4282), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4282) },
                    { 9, "A", 2, 19, "3+1", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4284), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4284) },
                    { 10, "B", 9, 111, "2+1", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4287), true, true, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4287) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "user_id", "apartment_id", "CarPlate", "email", "identity_number", "membership_date", "active", "delete_status", "name", "password", "phone_number", "status", "surname", "update_date" },
                values: new object[,]
                {
                    { 1, 1, null, "admin@gmail.com", "82842683832", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3616), true, false, "Beyza", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 55", "Admin", "Cabuk", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3623) },
                    { 2, 2, null, "e.yildirim@gmail.com", "34965092008", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3810), true, false, "Erkan", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 56", "Resident", "Yıldırım", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3811) },
                    { 3, 3, null, "s.yilmaz@gmail.com", "78185721324", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3836), true, false, "Serkan", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 57", "Resident", "Yılmaz", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3836) },
                    { 4, 4, null, "g.aslan@gmail.com", "97968823406", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3856), true, false, "Gürkan", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 58", "Resident", "Aslan", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3857) },
                    { 5, 5, null, "c.aslan@gmail.com", "80829170948", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3901), true, false, "Cansu", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 59", "Resident", "Aslan", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3902) },
                    { 6, 6, null, "b.kaplan@gmail.com", "89076741888", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3922), true, false, "Banu", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 60", "Resident", "Kaplan", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3923) },
                    { 7, 7, null, "h.atak@gmail.com", "13060621122", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3940), true, false, "Hülya", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 61", "Resident", "Atak", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3940) },
                    { 8, 8, null, "l.atak@gmail.com", "25120656692", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3957), true, false, "Leyla", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 62", "Resident", "Atak", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3958) },
                    { 9, 9, null, "a.gul@gmail.com", "53465893878", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3998), true, false, "Aslı", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 63", "Resident", "Gül", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(3999) },
                    { 10, 10, null, "i.yaylaci@gmail.com", "55690108116", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4017), true, false, "İpek", "25b80b3556ca3a15353dd2fd312062fad27adcf5a1de51b75bdadea1fa8214ab", "0555 555 55 64", "Resident", "Yaylacı", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4018) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Bill",
                columns: new[] { "bill_id", "apartment_id", "amount", "category", "due_date", "assign_date", "month", "update_date", "user_id" },
                values: new object[,]
                {
                    { 1, 1, 300m, "gas", new DateTime(2023, 8, 30, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4163), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4162), 9, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4163), 1 },
                    { 2, 2, 220m, "water", new DateTime(2023, 8, 23, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4169), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4168), 9, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4168), 2 },
                    { 3, 3, 140m, "electric", new DateTime(2023, 8, 17, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4170), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4170), 8, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4170), 3 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Bill",
                columns: new[] { "bill_id", "apartment_id", "amount", "category", "due_date", "assign_date", "payment_status", "month", "update_date", "user_id" },
                values: new object[] { 4, 3, 50m, "other", new DateTime(2023, 8, 28, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4173), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4172), true, 9, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4172), 3 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Bill",
                columns: new[] { "bill_id", "apartment_id", "amount", "category", "due_date", "assign_date", "month", "update_date", "user_id" },
                values: new object[] { 5, 4, 80m, "electric", new DateTime(2023, 8, 17, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4174), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4173), 8, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4174), 4 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Bill",
                columns: new[] { "bill_id", "apartment_id", "amount", "category", "due_date", "assign_date", "payment_status", "month", "update_date", "user_id" },
                values: new object[] { 6, 5, 230m, "electric", new DateTime(2023, 8, 13, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4176), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4175), true, 8, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4175), 5 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Bill",
                columns: new[] { "bill_id", "apartment_id", "amount", "category", "due_date", "assign_date", "month", "update_date", "user_id" },
                values: new object[,]
                {
                    { 7, 6, 600m, "gas", new DateTime(2023, 8, 27, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4178), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4177), 8, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4178), 6 },
                    { 8, 6, 30m, "other", new DateTime(2023, 8, 12, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4180), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4179), 8, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4179), 6 },
                    { 9, 6, 80m, "water", new DateTime(2023, 8, 19, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4181), new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4181), 8, new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4181), 6 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Message",
                columns: new[] { "message_id", "content", "received_date", "IsDeleted", "is_read", "receiver_id", "receiver_name", "receiver_surname", "sender_name", "sender_surname", "subject", "read_date", "sender_id" },
                values: new object[,]
                {
                    { 1, "Sayın admin. Geceleri birinci kattan gelen yüksek müzik nedeniyle uyuyamıyoruz. Lütfen gereğini yapın!", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4100), false, false, 1, null, null, null, null, "Müzik gürültüsü", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4100), 2 },
                    { 2, "Asansördeki elektrik sürekli kopuyor ve tedirgin oluyoruz. Lütfen gereğini yapın", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4103), false, false, 1, null, null, null, null, "Asansör Işığı", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4103), 3 },
                    { 3, "Sayın komşu. Katınızda yarın sabah 9.00-11.00 saatleri arasında boru tadilatı yapılacaktır. Bilginize. Yönetici.", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4105), false, false, 2, null, null, null, null, "Tadilat", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4105), 1 },
                    { 4, "Sayın yönetici. Son günlerde sitemizde hırsızlık olayları artmıştır. Ailecek tedirgin oluyoruz. Lütfen gereğini yapın.", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4106), false, false, 1, null, null, null, null, "Hırsız sorunu", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4106), 5 },
                    { 5, "Sayın yönetici. Çöplerimiz 3 gündür alınmıyor. Lütfen gereğini yapın.", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4107), false, false, 1, null, null, null, null, "Çöpler", new DateTime(2023, 8, 10, 4, 38, 24, 182, DateTimeKind.Local).AddTicks(4107), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_apartment_id",
                schema: "dbo",
                table: "Bill",
                column: "apartment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_user_id",
                schema: "dbo",
                table: "Bill",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Card_UserId",
                table: "Card",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_sender_id",
                schema: "dbo",
                table: "Message",
                column: "sender_id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserApartments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Apartment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
