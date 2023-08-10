using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordGenerator;
using ResiPay.DB.Entities;
using ResiPay.DB.Helpers;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResiPay.DB.SeedDatas
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> entity)
        {

            var user = new User
            {
                Id = 1,
                Name = "Beyza",
                Surname = "Cabuk",
                Email = "admin@gmail.com",
                IdentityNumber = "82842683832",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsActive = true,
                Status = "Admin",
                IsDelete = false,
                PhoneNumber = "0555 555 55 55",
                ApartmentId = 1,
                Password = "deneme"

            };


            entity.HasData(user);

            entity.HasData(new User
            {
                Id = 2,
                Name = "Erkan",
                Surname = "Yıldırım",
                Email = "e.yildirim@gmail.com",
                IdentityNumber = "34965092008",
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsActive = true,
                Status = "Resident",
                IsDelete = false,
                PhoneNumber = "0555 555 55 56",
                ApartmentId = 2,
                Password = Hasher.GetHash("deneme")

            },

           new User
           {
               Id = 3,
               Name = "Serkan",
               Surname = "Yılmaz",
               Email = "s.yilmaz@gmail.com",
               IdentityNumber = "78185721324",
               InsertDate = DateTime.Now,
               UpdateDate = DateTime.Now,
               IsActive = true,
               Status = "Resident",
               IsDelete = false,
               PhoneNumber = "0555 555 55 57",
               ApartmentId = 3,
               Password = Hasher.GetHash("deneme")

           },

           new User
           {
               Id = 4,
               Name = "Gürkan",
               Surname = "Aslan",
               Email = "g.aslan@gmail.com",
               IdentityNumber = "97968823406",
               InsertDate = DateTime.Now,
               UpdateDate = DateTime.Now,
               IsActive = true,
               Status = "Resident",
               IsDelete = false,
               PhoneNumber = "0555 555 55 58",
               ApartmentId = 4,
               Password = Hasher.GetHash("deneme")

           },

           new User
           {
               Id = 5,
               Name = "Cansu",
               Surname = "Aslan",
               Email = "c.aslan@gmail.com",
               IdentityNumber = "80829170948",
               InsertDate = DateTime.Now,
               UpdateDate = DateTime.Now,
               IsActive = true,
               Status = "Resident",
               IsDelete = false,
               PhoneNumber = "0555 555 55 59",
               ApartmentId = 5,
               Password = Hasher.GetHash("deneme")

           },

           new User
           {
               Id = 6,
               Name = "Banu",
               Surname = "Kaplan",
               Email = "b.kaplan@gmail.com",
               IdentityNumber = "89076741888",
               InsertDate = DateTime.Now,
               UpdateDate = DateTime.Now,
               IsActive = true,
               Status = "Resident",
               IsDelete = false,
               PhoneNumber = "0555 555 55 60",
               ApartmentId = 6,
               Password = Hasher.GetHash("deneme")

           },

           new User
           {
               Id = 7,
               Name = "Hülya",
               Surname = "Atak",
               Email = "h.atak@gmail.com",
               IdentityNumber = "13060621122",
               InsertDate = DateTime.Now,
               UpdateDate = DateTime.Now,
               IsActive = true,
               Status = "Resident",
               IsDelete = false,
               PhoneNumber = "0555 555 55 61",
               ApartmentId = 7,
               Password = Hasher.GetHash("deneme")

           },

           new User
           {
               Id = 8,
               Name = "Leyla",
               Surname = "Atak",
               Email = "l.atak@gmail.com",
               IdentityNumber = "25120656692",
               InsertDate = DateTime.Now,
               UpdateDate = DateTime.Now,
               IsActive = true,
               Status = "Resident",
               IsDelete = false,
               PhoneNumber = "0555 555 55 62",
               ApartmentId = 8,
               Password = Hasher.GetHash("deneme")

           },

           new User
           {
               Id = 9,
               Name = "Aslı",
               Surname = "Gül",
               Email = "a.gul@gmail.com",
               IdentityNumber = "53465893878",
               InsertDate = DateTime.Now,
               UpdateDate = DateTime.Now,
               IsActive = true,
               Status = "Resident",
               IsDelete = false,
               PhoneNumber = "0555 555 55 63",
               ApartmentId = 9,
               Password = Hasher.GetHash("deneme")

           },

           new User
           {
               Id = 10,
               Name = "İpek",
               Surname = "Yaylacı",
               Email = "i.yaylaci@gmail.com",
               IdentityNumber = "55690108116",
               InsertDate = DateTime.Now,
               UpdateDate = DateTime.Now,
               IsActive = true,
               Status = "Resident",
               IsDelete = false,
               PhoneNumber = "0555 555 55 64",
               ApartmentId = 10,
               Password = Hasher.GetHash("deneme")

           });
        }
    }
}
