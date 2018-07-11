using MediatR;
using Northwind.Application.Games.Models;

namespace Northwind.Application.Games.Queries
{
    public class GetAllGamesQuery : IRequest<GamesListViewModel>
    {
        public readonly GetAllGamesQueryParams GetAllGamesQueryParams;

        public GetAllGamesQuery(GetAllGamesQueryParams getAllGamesQueryParams)
        {
            GetAllGamesQueryParams = getAllGamesQueryParams;
        }
    }
}