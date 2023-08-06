﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ResiPay.DB;

#nullable disable

namespace ResiPay.DB.Migrations
{
    [DbContext(typeof(ResiPayDbContext))]
    [Migration("20230806111210_DbChangesv21")]
    partial class DbChangesv21
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApartmentUser", b =>
                {
                    b.Property<int>("ApartmentsId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("ApartmentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserApartments", "dbo");
                });

            modelBuilder.Entity("ResiPay.DB.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("apartmen_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApartmentBlock")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("block");

                    b.Property<int>("ApartmentFloor")
                        .HasColumnType("integer")
                        .HasColumnName("floor");

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("integer")
                        .HasColumnName("no");

                    b.Property<string>("ApartmentType")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasColumnName("type");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("date")
                        .HasColumnName("insert_date");

                    b.Property<bool>("IsFull")
                        .HasColumnType("boolean")
                        .HasColumnName("is_full");

                    b.Property<bool>("IsRented")
                        .HasColumnType("boolean")
                        .HasColumnName("is_rented");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("date")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.ToTable("Apartment", "dbo");
                });

            modelBuilder.Entity("ResiPay.DB.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("bill_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("integer")
                        .HasColumnName("apartment_id");

                    b.Property<decimal>("BillAmount")
                        .HasColumnType("numeric(15,2)")
                        .HasColumnName("amount");

                    b.Property<string>("BillType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date")
                        .HasColumnName("due_date");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("date")
                        .HasColumnName("assign_date");

                    b.Property<bool>("IsPaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("payment_status");

                    b.Property<int>("Month")
                        .HasMaxLength(30)
                        .HasColumnType("integer")
                        .HasColumnName("month");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("date")
                        .HasColumnName("update_date");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Bill", "dbo");
                });

            modelBuilder.Entity("ResiPay.DB.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("message_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("content");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("date")
                        .HasColumnName("received_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean")
                        .HasColumnName("is_read");

                    b.Property<int>("ReceiverId")
                        .HasMaxLength(30)
                        .HasColumnType("integer")
                        .HasColumnName("receiver_id");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("receiver_name");

                    b.Property<string>("ReceiverSurname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("recever_surname");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("sender_name");

                    b.Property<string>("SenderSurname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("sender_surname");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("subject");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("date")
                        .HasColumnName("read_date");

                    b.Property<int>("UserId")
                        .HasMaxLength(30)
                        .HasColumnType("integer")
                        .HasColumnName("sender_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Message", "dbo");
                });

            modelBuilder.Entity("ResiPay.DB.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("integer")
                        .HasColumnName("apartment_id");

                    b.Property<string>("CarPlate")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("email");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("identity_number");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("date")
                        .HasColumnName("membership_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean")
                        .HasColumnName("delete_status");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("surname");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("date")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("IdentityNumber");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("ApartmentUser", b =>
                {
                    b.HasOne("ResiPay.DB.Entities.Apartment", null)
                        .WithMany()
                        .HasForeignKey("ApartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResiPay.DB.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResiPay.DB.Entities.Bill", b =>
                {
                    b.HasOne("ResiPay.DB.Entities.Apartment", "Apartment")
                        .WithMany("Bills")
                        .HasForeignKey("ApartmentId")
                        .IsRequired();

                    b.HasOne("ResiPay.DB.Entities.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResiPay.DB.Entities.Message", b =>
                {
                    b.HasOne("ResiPay.DB.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResiPay.DB.Entities.Apartment", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("ResiPay.DB.Entities.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
