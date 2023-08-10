using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResiPay.DB.Entities;
using System;

namespace ResiPay.DB.SeedDatas
{
    public class ApartmentSeed : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {

            builder.HasData(new Apartment
            {
                Id = 1,
                ApartmentBlock = "A",
                ApartmentFloor = 4,
                ApartmentNumber = 44,
                ApartmentType = "2+1",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 2,
                ApartmentBlock = "B",
                ApartmentFloor = 3,
                ApartmentNumber = 34,
                ApartmentType = "1+1",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 3,
                ApartmentBlock = "C",
                ApartmentFloor = 5,
                ApartmentNumber = 65,
                ApartmentType = "3+1",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 4,
                ApartmentBlock = "B",
                ApartmentFloor = 5,
                ApartmentNumber = 63,
                ApartmentType = "2+1",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 5,
                ApartmentBlock = "D",
                ApartmentFloor = 7,
                ApartmentNumber = 87,
                ApartmentType = "1+0",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 6,
                ApartmentBlock = "G",
                ApartmentFloor = 13,
                ApartmentNumber = 144,
                ApartmentType = "3+0",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 7,
                ApartmentBlock = "E",
                ApartmentFloor = 6,
                ApartmentNumber = 78,
                ApartmentType = "1+0",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 8,
                ApartmentBlock = "D",
                ApartmentFloor = 3,
                ApartmentNumber = 33,
                ApartmentType = "1+1",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 9,
                ApartmentBlock = "A",
                ApartmentFloor = 2,
                ApartmentNumber = 19,
                ApartmentType = "3+1",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            },

            new Apartment
            {
                Id = 10,
                ApartmentBlock = "B",
                ApartmentFloor = 9,
                ApartmentNumber = 111,
                ApartmentType = "2+1",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsFull = true,
                IsRented = true

            });
        }
    }
}
