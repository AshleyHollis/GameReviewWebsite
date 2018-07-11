using MediatR;
using Northwind.Application.Games.Models;

namespace Northwind.Application.Games.Commands
{
    public class UpdateGameCommand : IRequest<GameDto>
    {
        public GameDto Game { get; set; }
    }
}