using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Domain.Entities;

namespace Northwind.Persistence
{
    public class NorthwindInitializer
    {
        private readonly Dictionary<int, Game> Games = new Dictionary<int, Game>();
        private readonly Dictionary<int, Rating> Ratings = new Dictionary<int, Rating>();

        public static void Initialize(NorthwindDbContext context)
        {
            var initializer = new NorthwindInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(NorthwindDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Games.Any())
            {
                return; // Db has been seeded
            }

            SeedGames(context);
            SeedRatings(context);
        }

        public void SeedGames(NorthwindDbContext context)
        {
            var games = new[]
            {
                new Game { Title = "Gears of War 3", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit" },
                new Game { Title = "Step Up for Kinnect", Description = "Integer magna magna, iaculis euismodtincidunt a, cursus ac dolor. Aenean quis egestas diam. Pellentesque purus ipsum, elementum sit amet malesuada eget, aliquet eu magna. Nullam magna massa, sodales nec imperdiet quis, consectetur eget nisl. Aenean eget velit in eros porta dictum. Sed eu dui in augu"},
                new Game { Title = "Dead Island", Description = "Vivamus purus eros, aliquet malesuada gravida at, fringilla vel elit. Mauris vestibulum, erat at volutpat semper, metus enim faucibus nunc, in ultrices magna enim in justo"},
            };

            context.Games.AddRange(games);

            context.SaveChanges();
        }

        private void SeedRatings(NorthwindDbContext context)
        {
            var ratings = new[]
            {
                new Rating{ GameId = 1, RatingValue = 5},
                new Rating{ GameId = 2, RatingValue = 1},
                new Rating{ GameId = 3, RatingValue = 3},
            };

            context.Ratings.AddRange(ratings);

            context.SaveChanges();
        }        

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}