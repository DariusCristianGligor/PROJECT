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
    class ReviewConfig : IEntityTypeConfiguration<Review>
    {

        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasOne(x => x.Place)
                 .WithMany(y => y.Reviews)
                 .HasForeignKey(y => y.IdPlAce);
        }


    }
}
