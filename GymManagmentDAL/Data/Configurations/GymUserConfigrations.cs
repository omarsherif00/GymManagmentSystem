using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Configurations
{
    internal class GymUserConfigrations<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
          builder.Property(X=>X.Name).HasColumnType("Varchar(50)");

            builder.Property(X => X.Email)
                .HasColumnType("varchar(100)");

            builder.ToTable(tb => tb.HasCheckConstraint("EmailValidFormatConstraint", "Email like '_%@_%._%"));

            builder.HasIndex(X=>X.Email).IsUnique();

            builder.Property(X => X.Phone)
             .HasColumnType("varchar(11)");

            builder.ToTable(Tb => Tb.HasCheckConstraint("phoneValidEgp", "Phone like '01' and phone not like %[0-9]%"));


            builder.HasIndex(X => X.Phone).IsUnique();

            builder.OwnsOne(X => X.Address, AddressBuilder => { 
            AddressBuilder.Property(A=>A.)
            })
        }
    }
}
