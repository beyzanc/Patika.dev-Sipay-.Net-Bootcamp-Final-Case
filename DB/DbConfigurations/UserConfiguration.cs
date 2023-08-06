using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResiPay.DB.Entities;

namespace ResiPay.DB.DbConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.Property(x => x.Id)
                .IsRequired(true)
                .UseIdentityColumn()
                .HasColumnName("user_id");

            user.Property(x => x.InsertDate)
                .IsRequired(true)
                .HasColumnType("date")
                .HasColumnName("membership_date");

            user.Property(x => x.UpdateDate)
                .HasColumnType("date")
                .IsRequired(true)
                .HasColumnName("update_date");

            user.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(40)
                .HasColumnName("name");

            user.Property(x => x.Surname)
                .IsRequired(true)
                .HasMaxLength(40)
                .HasColumnName("surname");

            user.Property(x => x.IdentityNumber)
                .IsRequired(true)
                .HasMaxLength(11)
                .HasColumnName("identity_number");

            user.Property(x => x.Email)
                .IsRequired(true)
                .HasColumnName("email")
                .HasMaxLength(40);

            user.Property(x => x.Password)
                .IsRequired(true)
                .HasColumnName("password")
                .HasMaxLength(100);

            user.Property(x => x.PhoneNumber)
                .IsRequired(true)
                .HasColumnName("phone_number");

            user.Property(x => x.CarPlate)
                .HasMaxLength(20);

            user.Property(x => x.IsActive)
                .IsRequired(true)
                .HasColumnName("active");

            user.Property(x => x.IsDelete)
                .IsRequired(true)
                .HasColumnName("delete_status");

            user.Property(x => x.ApartmentId)
                .IsRequired(true)
                .HasColumnName("apartment_id");


            user.HasIndex(x => x.IdentityNumber);

            user.HasMany(x => x.Apartments)
                .WithMany(x => x.Users)
                .UsingEntity(j => j.ToTable("UserApartments", "dbo"));

            user.HasMany(x => x.Bills)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            user.HasMany(x => x.Cards)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

        }
    }
}
