using Microsoft.AspNetCore.Mvc;
using myapiP.Models;
using myapiP.Services;

namespace myapiP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost("play")]
    public ActionResult<GameResult> Play([FromBody] GameMoveRequest request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Move))
        {
            return BadRequest("Move parameter is required.");
        }

        if (!Enum.TryParse<GameMove>(request.Move, ignoreCase: true, out var playerMove))
        {
            return BadRequest("Invalid move. Valid moves are: Rock, Paper, Scissors, Lizard, Spock");
        }

        var result = _gameService.Play(playerMove);
        return Ok(result);
    }
}

public class GameMoveRequest
{
    public string? Move { get; set; }
}
