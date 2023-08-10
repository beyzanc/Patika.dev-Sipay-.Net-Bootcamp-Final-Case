using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResiPay.DB.Entities;
using System;

namespace ResiPay.DB.SeedDatas
{
    public class BillSeed : IEntityTypeConfiguration<Bill>
    {

        public void Configure(EntityTypeBuilder<Bill> builder)
        {

            builder.HasData(new Bill
            {
                Id = 1,
                BillAmount = 300,
                BillType = "gas",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = false,
                DueDate = DateTime.Now.AddDays(20),
                Month = Enums.Month.September,
                ApartmentId = 1,
                UserId = 1,

            },

            new Bill
            {
                Id = 2,
                BillAmount = 220,
                BillType = "water",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = false,
                DueDate = DateTime.Now.AddDays(13),
                Month = Enums.Month.September,
                ApartmentId = 2,
                UserId = 2,

            },

            new Bill
            {
                Id = 3,
                BillAmount = 140,
                BillType = "electric",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = false,
                DueDate = DateTime.Now.AddDays(7),
                Month = Enums.Month.August,
                ApartmentId = 3,
                UserId = 3,

            },

            new Bill
            {
                Id = 4,
                BillAmount = 50,
                BillType = "other",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = true,
                DueDate = DateTime.Now.AddDays(18),
                Month = Enums.Month.September,
                ApartmentId = 3,
                UserId = 3,

            },

            new Bill
            {
                Id = 5,
                BillAmount = 80,
                BillType = "electric",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = false,
                DueDate = DateTime.Now.AddDays(7),
                Month = Enums.Month.August,
                ApartmentId = 4,
                UserId = 4,

            },

            new Bill
            {
                Id = 6,
                BillAmount = 230,
                BillType = "electric",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = true,
                DueDate = DateTime.Now.AddDays(3),
                Month = Enums.Month.August,
                ApartmentId = 5,
                UserId = 5,

            },

            new Bill
            {
                Id = 7,
                BillAmount = 600,
                BillType = "gas",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = false,
                DueDate = DateTime.Now.AddDays(17),
                Month = Enums.Month.August,
                ApartmentId = 6,
                UserId = 6,

            },

            new Bill
            {
                Id = 8,
                BillAmount = 30,
                BillType = "other",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = false,
                DueDate = DateTime.Now.AddDays(2),
                Month = Enums.Month.August,
                ApartmentId = 6,
                UserId = 6,

            },

            new Bill
            {
                Id = 9,
                BillAmount = 80,
                BillType = "water",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsPaid = false,
                DueDate = DateTime.Now.AddDays(9),
                Month = Enums.Month.August,
                ApartmentId = 6,
                UserId = 6,

            });
        }
    }
}

