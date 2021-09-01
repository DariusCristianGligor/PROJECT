using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CountryData.Standard;

namespace Infrastructure
{
    class CountryConfig : IEntityTypeConfiguration<Domain.Country>
    {
        public void Configure(EntityTypeBuilder<Domain.Country> builder)
        {
            builder.HasMany<City>(x => x.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c=>c.CountryId);
            
        }
    }
}
