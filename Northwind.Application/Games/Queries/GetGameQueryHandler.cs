using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Application.Games.Models;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Games.Queries
{
    public class GetGameQueryHandler : MediatR.IRequestHandler<GetGameQuery, GameViewModel>
    {
        private readonly NorthwindDbContext _context;

        public GetGameQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<GameViewModel> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var game = await _context.Games
                .Where(p => p.GameId == request.Id)
                .Select(GameDto.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if (game == null)
            {
                throw new EntityNotFoundException(nameof(Game), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            var model = new GameViewModel
            {
                Game = game,
                EditEnabled = true,
                DeleteEnabled = false
            };

            return model;
        }
    }
}