using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    public class AuthorConfigs : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id).HasName("Writers");
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Birthdate)
                    .HasColumnName("DateOfBirth")
                    .IsRequired(false);
            builder.Ignore(x => x.FullName);

            // Configure Relationships
            builder.HasOne(x => x.Country)
                    .WithMany(x => x.Authors)
                    .HasForeignKey(x => x.CountryId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(x => x.Books).WithMany(x => x.Authors);
        }
    }
}
