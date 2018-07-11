using System.Collections.Generic;

namespace Northwind.Domain.Entities
{
    public class Game
    {
        public Game()
        {
            Ratings = new List<Rating>();
        }

        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Rating> Ratings { get; private set; }
    }
}
