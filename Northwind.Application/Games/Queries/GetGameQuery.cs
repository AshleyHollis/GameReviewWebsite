using MediatR;
using Northwind.Application.Games.Models;

namespace Northwind.Application.Games.Queries
{
    public class GetGameQuery : IRequest<GameViewModel>
    {
        public GetGameQuery()
        {
        }

        public GetGameQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}