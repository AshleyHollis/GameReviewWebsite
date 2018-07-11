using System.Collections.Generic;

namespace Northwind.Domain.Entities
{
    public class Rating
    {
        public Rating()
        {
            
        }

        public int RatingId { get; set; }
        public int GameId { get; set; }
        public int RatingValue { get; set; }

        public Game Game { get; set; }
    }
}