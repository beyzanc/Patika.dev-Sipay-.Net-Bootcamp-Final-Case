using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ResiPay.DB.Entities;
using System;

namespace ResiPay.DB.SeedDatas
{
    public class MessageSeed : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {

            builder.HasData(new Message
            {
                Id = 1,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Subject = "Müzik gürültüsü",
                Content = "Sayın admin. Geceleri birinci kattan gelen yüksek müzik nedeniyle uyuyamıyoruz. Lütfen gereğini yapın!",
                IsDeleted = false,
                IsRead = false,
                ReceiverId = 1,
                UserId = 2,

            },

            new Message
            {
                Id = 2,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Subject = "Asansör Işığı",
                Content = "Asansördeki elektrik sürekli kopuyor ve tedirgin oluyoruz. Lütfen gereğini yapın",
                IsDeleted = false,
                IsRead = false,
                ReceiverId = 1,
                UserId = 3,

            },

            new Message
            {
                Id = 3,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Subject = "Tadilat",
                Content = "Sayın komşu. Katınızda yarın sabah 9.00-11.00 saatleri arasında boru tadilatı yapılacaktır. Bilginize. Yönetici.",
                IsDeleted = false,
                IsRead = false,
                ReceiverId = 2,
                UserId = 1,

            },

            new Message
            {
                Id = 4,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Subject = "Hırsız sorunu",
                Content = "Sayın yönetici. Son günlerde sitemizde hırsızlık olayları artmıştır. Ailecek tedirgin oluyoruz. Lütfen gereğini yapın.",
                IsDeleted = false,
                IsRead = false,
                ReceiverId = 1,
                UserId = 5,

            },

            new Message
            {
                Id = 5,
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Subject = "Çöpler",
                Content = "Sayın yönetici. Çöplerimiz 3 gündür alınmıyor. Lütfen gereğini yapın.",
                IsDeleted = false,
                IsRead = false,
                ReceiverId = 1,
                UserId = 4,

            });
        }              
    }
}
