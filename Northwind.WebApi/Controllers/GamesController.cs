using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Games.Models;
using Northwind.Application.Games.Queries;
using Northwind.WebApi.Infrastructure;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : BaseController
    {
        // GET: api/Games
        [HttpGet]
        public Task<GamesListViewModel> GetGames()
        {
            return Mediator.Send(new GetAllGamesQuery());
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GameViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGame(int id)
        {
            return Ok(await Mediator.Send(new GetGameQuery(id)));
        }

        // POST: api/Games
        //[HttpPost]
        //[ProducesResponseType(typeof(GameViewModel), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> PostProduct([FromBody] CreateGameCommand command)
        //{
        //    var viewModel = await Mediator.Send(command);

        //    return CreatedAtAction("GetGame", new { id = viewModel.Game.GameId }, viewModel);
        //}

        // PUT: api/Games/5
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(GameDto), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> PutGame(
        //    [FromRoute] int id,
        //    [FromBody] UpdateGameCommand command)
        //{
        //    if (id != command.Game.GameId)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(await Mediator.Send(command));
        //}

        // DELETE: api/Games/5
        //[HttpDelete("{id}")]
        //[ProducesResponseType((int)HttpStatusCode.NoContent)]
        //public async Task<IActionResult> DeleteGame(int id)
        //{
        //    await Mediator.Send(new DeleteGameCommand(id));

        //    return NoContent();
        //}
    }
}