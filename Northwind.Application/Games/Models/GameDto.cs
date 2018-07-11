using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Northwind.Domain.Entities;

namespace Northwind.Application.Games.Models
{
    public class GameDto
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Rating { get; set; }

        public static Expression<Func<Game, GameDto>> Projection
        {
            get
            {
                return g => new GameDto
                {
                    GameId = g.GameId,
                    Title = g.Title,
                    Description =  g.Description,
                    Rating = CalculateRating(g.Ratings)
                };
            }
        }

        private static double? CalculateRating(ICollection<Rating> ratings)
        {
            if (ratings == null || !ratings.Any())
            {
                return null;
            }

            return ratings.Average(r => r.RatingValue);
        }

        public static GameDto Create(Game game)
        {
            return Projection.Compile().Invoke(game);
        }

    }
}