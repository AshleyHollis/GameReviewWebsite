using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(e => e.RatingId);

            builder.Property(e => e.RatingId).HasColumnName("RatingID");

            builder.Property(e => e.RatingValue)
                .IsRequired();

            builder.HasOne(e => e.Game)
                .WithMany(g => g.Ratings);
        }
    }
}
