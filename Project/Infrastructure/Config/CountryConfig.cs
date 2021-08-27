using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(30);
            builder.HasMany<City>(x => x.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c=>c.CountryId);
        }
    }
}
