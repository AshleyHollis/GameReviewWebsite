using MediatR;
using Northwind.Application.Games.Models;

namespace Northwind.Application.Games.Commands
{
    public class VoteGameCommand : IRequest<GameViewModel>
    {
        public VoteGameCommand(int gameId, int ratingValue)
        {
            GameId = gameId;
            RatingValue = ratingValue;
        }

        public readonly int GameId;
        public readonly int RatingValue;
    }
}