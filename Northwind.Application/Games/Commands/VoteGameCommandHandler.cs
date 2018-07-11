using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Application.Games.Models;
using Northwind.Application.Games.Queries;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Games.Commands
{
    public class VoteGameCommandHandler : IRequestHandler<VoteGameCommand, GameViewModel>
    {
        private readonly NorthwindDbContext _context;
        private readonly IMediator _mediator;

        public VoteGameCommandHandler(NorthwindDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<GameViewModel> Handle(VoteGameCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Games
                .FindAsync(request.GameId);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Game), request.GameId);
            }

            var rating = new Rating{ GameId = request.GameId, RatingValue = request.RatingValue };

            _context.Ratings.Add(rating);

            await _context.SaveChangesAsync(cancellationToken);

            return await _mediator.Send(new GetGameQuery(request.GameId), cancellationToken);
        }
    }
}