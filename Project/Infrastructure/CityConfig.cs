﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class CityConfig: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(30);
            builder.HasOne(e => e.Country)
            .WithMany(c => c.Cities).HasForeignKey(e=>e.IdCountry);
            builder.HasMany(e => e.Places)
                .WithOne(x => x.City).HasForeignKey(x=>x.IdCity);
            //fluent api.ef core
        }


    }
}
