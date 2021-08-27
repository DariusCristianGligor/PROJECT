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
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {   
            builder.Property(x => x.Name)
                .HasMaxLength(30);
            builder.HasMany<Place>(x => x.Places)
                .WithMany(y=>y.Categories);
        }
    }
}
