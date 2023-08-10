using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResiPay.DB.Entities;

namespace ResiPay.DB.DbConfigurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> bill)
        {
            bill.Property(x => x.Id)
                .IsRequired(true)
                .UseIdentityColumn()
                .HasColumnName("bill_id");

            bill.Property(x => x.InsertDate)
                .IsRequired(true)
                .HasColumnType("date")
                .HasColumnName("assign_date");

            bill.Property(x => x.UpdateDate)
                .IsRequired(true)
                .HasColumnType("date")
                .HasColumnName("update_date");

            bill.Property(x => x.ApartmentId)
                .IsRequired(true)
                .HasColumnName("apartment_id");

            bill.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnName("user_id");

            bill.Property(x => x.BillType)
                .IsRequired(true)
                .HasColumnName("category");

            bill.Property(x => x.BillAmount)
                .IsRequired (true)
                .HasColumnName("amount")
                .HasColumnType("decimal(15, 2)");

            bill.Property(x => x.DueDate)
                .IsRequired(true)
                .HasColumnType("date")
                .HasColumnName("due_date");

            bill.Property(x => x.Month)
                .IsRequired(true)
                .HasColumnName("month")
                .HasMaxLength(30);
            
            bill.Property(x => x.IsPaid)
                .IsRequired(true)
                .HasColumnName("payment_status")
                .HasDefaultValue (false);

        }
    }
}
