using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.GameId);

            builder.Property(e => e.GameId)
                .HasColumnName("GameID");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Description)
                .HasColumnType("ntext");

            builder.HasMany(e => e.Ratings)
                .WithOne(r => r.Game);
        }
    }
}