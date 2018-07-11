using System;
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
                    Rating = g.Ratings != null ? g.Ratings.Average(r => r.RatingValue) : (double?) null
                };
            }
        }

        public static GameDto Create(Game game)
        {
            return Projection.Compile().Invoke(game);
        }

    }
}