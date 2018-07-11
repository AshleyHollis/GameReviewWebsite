using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Games.Models;
using Northwind.Domain.Extentions;
using Northwind.Persistence;

namespace Northwind.Application.Games.Queries
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, GamesListViewModel>
    {
        private readonly NorthwindDbContext _context;

        public GetAllGamesQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<GamesListViewModel> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Games
                .Select(GameDto.Projection);

            if (IsValidDatabaseField(request))
                query = query.Sort(request.GetAllGamesQueryParams.SortBy);

            var games = await query.ToListAsync(cancellationToken);

            if (IsValidDtoField(request))
                games = games.Sort(request.GetAllGamesQueryParams.SortBy);

            var model = new GamesListViewModel
            {
                Games = games
            };

            return model;
        }

        private static bool IsValidDtoField(GetAllGamesQuery request)
        {
            return !string.IsNullOrEmpty(request.GetAllGamesQueryParams.SortBy) 
                   && typeof(GameDto).HasProperty(request.GetAllGamesQueryParams.SortBy);
        }

        private static bool IsValidDatabaseField(GetAllGamesQuery request)
        {
            return !string.IsNullOrEmpty(request.GetAllGamesQueryParams.SortBy) 
                   && typeof(Domain.Entities.Game).HasProperty(request.GetAllGamesQueryParams.SortBy) 
                   && !StringComparer.InvariantCultureIgnoreCase.Equals(request.GetAllGamesQueryParams.SortBy, nameof(Domain.Entities.Game.Description)); // Can't sort on Description field as it's a ntext data type in the database.
        }
    }
}