using System.Collections.Generic;

namespace Northwind.Application.Games.Models
{
    public class GamesListViewModel
    {
        public IEnumerable<GameDto> Games { get; set; }

        public bool CreateEnabled { get; set; }
    }
}