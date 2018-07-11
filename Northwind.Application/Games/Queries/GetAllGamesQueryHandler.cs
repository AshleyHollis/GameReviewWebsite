using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Games.Models;
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
            var model = new GamesListViewModel
            {
                Games = await _context.Games
                    .Select(GameDto.Projection)
                    .OrderBy(g => g.Title)
                    .ToListAsync(cancellationToken)
            };

            return model;
        }
    }
}