using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResiPay.DB.Entities;

namespace ResiPay.DB.DbConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> message)
        {
            message.Property(x => x.Id)
                .IsRequired(true)
                .UseIdentityColumn()
                .HasColumnName("message_id");

            message.Property(x => x.InsertDate)
                .IsRequired(true)
                .HasColumnType("date")
                .HasColumnName("received_date");

            message.Property(x => x.UpdateDate)
                .IsRequired(true)
                .HasColumnType("date")
                .HasColumnName("read_date");

            message.Property(x => x.Subject)
                .IsRequired(true)
                .HasColumnName("subject")
                .HasMaxLength(25);

            message.Property(x => x.Content)
                .IsRequired(true)
                .HasColumnName("content")
                .HasMaxLength(150);

            message.Property(x => x.IsRead)
                .HasColumnName("is_read");

            message.Property(x => x.ReceiverName)
                .HasColumnName("receiver_name")
                .HasMaxLength(30);

            message.Property(x => x.ReceiverSurname)
                .HasColumnName("receiver_surname")
                .HasMaxLength(30);

            message.Property(e => e.SenderName)
                .HasColumnName("sender_name")
                .HasMaxLength(30);

            message.Property(e => e.SenderSurname)
                .HasColumnName("sender_surname")
                .HasMaxLength(30);

            message.Property(e => e.ReceiverId)
                .HasColumnName("receiver_id")
                .IsRequired(true);

            message.Property(e => e.UserId)
                .HasColumnName("sender_id")
                .IsRequired(true);
                    
                    
        }
    }
}
