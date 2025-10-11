using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Configurations
{
    internal class MemberConfiguration : GymUserConfigrations<Member>, IEntityTypeConfiguration<Member>
    {
        public new void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Member> builder)
        {
            builder.Property(X => X.CreatedAt).HasColumnName("JoinDate")
                .HasDefaultValueSql("GETDATE()");

            base.Configure(builder); 
        }
    }
}
