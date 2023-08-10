using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResiPay.DB.Entities;

namespace ResiPay.DB.DbConfigurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> apartment)
        {
            apartment.Property(x => x.Id)
                .IsRequired(true)
                .UseIdentityColumn()
                .HasColumnName("apartment_id");

            apartment.Property(x => x.InsertDate)
                .IsRequired(true)
                .HasColumnType("date")
                .HasColumnName("insert_date");

            apartment.Property(x => x.UpdateDate)
                .IsRequired(true)
                .HasColumnType("date")
                .HasColumnName("update_date");

            apartment.Property(x => x.ApartmentBlock)
                .IsRequired(true)
                .HasColumnName("block")
                .HasMaxLength(20);

            apartment.Property(x => x.ApartmentFloor)
                .IsRequired(true)
                .HasColumnName("floor");

            apartment.Property(x => x.ApartmentNumber)
                .IsRequired(true)
                .HasColumnName("no");

            apartment.Property(x => x.ApartmentType)
                .HasColumnType("character varying(20)")
                .IsRequired(true)
                .HasColumnName("type");

            apartment.Property(x => x.IsFull)
                .IsRequired(true)
                .HasColumnName("is_full");

            apartment.Property(x => x.IsRented)
                .IsRequired(true)
                .HasColumnName("is_rented");


            apartment.HasMany(a => a.Bills)
                .WithOne(b => b.Apartment)
                .HasForeignKey(b => b.ApartmentId);

        }
    }
}
