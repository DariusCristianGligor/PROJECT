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
    class PlaceConfig: IEntityTypeConfiguration<Place>
    {
       
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(30);
            builder.HasMany(e => e.Reviews)
                .WithOne(c => c.Place).HasForeignKey(e=>e.Id);
            builder.HasMany(e => e.Categories);
            builder.HasOne(c => c.City)
                .WithMany(x => x.Places);
        }
    }
}
