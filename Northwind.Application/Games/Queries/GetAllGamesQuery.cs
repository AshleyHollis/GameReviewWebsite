using MediatR;
using Northwind.Application.Games.Models;

namespace Northwind.Application.Games.Queries
{
    public class GetAllGamesQuery : IRequest<GamesListViewModel>
    {
    }
}