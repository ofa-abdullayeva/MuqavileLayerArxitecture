using Entities.Concrate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.HasOne(u => u.AccessLevel)
                   .WithMany()
                   .HasForeignKey(u => u.AccessLevelId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
