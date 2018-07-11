using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Application.Games.Models;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Games.Commands
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, GameDto>
    {
        private readonly NorthwindDbContext _context;

        public UpdateGameCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<GameDto> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = request.Game;

            var entity = await _context.Games
                .FindAsync(game.GameId);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Game), game.GameId);
            }

            entity.GameId = game.GameId;
            entity.Title = game.Title;
            entity.Description = game.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return GameDto.Create(entity);
        }
    }
}