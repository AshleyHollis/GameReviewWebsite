namespace Northwind.Application.Games.Models
{
    public class GameViewModel
    {
        public GameDto Game { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }
    }
}