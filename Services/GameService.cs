using myapiP.Models;

namespace myapiP.Services;

public class GameService
{
    private readonly Random _random = new Random();

    public GameResult Play(GameMove playerMove)
    {
        // CPU makes a random move
        GameMove cpuMove = GetRandomMove();

        // Determine the outcome
        string outcome = DetermineOutcome(playerMove, cpuMove);
        string message = GenerateMessage(playerMove, cpuMove, outcome);
        // Return the result
        return new GameResult
        {
            PlayerMove = playerMove,
            CpuMove = cpuMove,
            Outcome = outcome,
            Message = message
        };
    }


    // Helper methods
    private GameMove GetRandomMove()
    {
        int moveIndex = _random.Next(5);
        return (GameMove)moveIndex;
    }
    // Determine the outcome of the game
    private string DetermineOutcome(GameMove playerMove, GameMove cpuMove)
    {
        if (playerMove == cpuMove)
            return "Draw";

        // Rock crushes Scissors, crushes Lizard
        // Paper covers Rock, disproves Spock
        // Scissors cuts Paper, decapitates Lizard
        // Lizard eats Paper, poisons Spock
        // Spock vaporizes Rock, smashes Scissors

        return playerMove switch
        {
            GameMove.Rock => cpuMove switch
            {
                GameMove.Scissors => "Win",
                GameMove.Lizard => "Win",
                _ => "Lose"
            },
            GameMove.Paper => cpuMove switch
            {
                GameMove.Rock => "Win",
                GameMove.Spock => "Win",
                _ => "Lose"
            },
            GameMove.Scissors => cpuMove switch
            {
                GameMove.Paper => "Win",
                GameMove.Lizard => "Win",
                _ => "Lose"
            },
            GameMove.Lizard => cpuMove switch
            {
                GameMove.Paper => "Win",
                GameMove.Spock => "Win",
                _ => "Lose"
            },
            GameMove.Spock => cpuMove switch
            {
                GameMove.Scissors => "Win",
                GameMove.Rock => "Win",
                _ => "Lose"
            },
            _ => "Draw"
        };
    }
    // Generate a message based on the outcome
    private string GenerateMessage(GameMove playerMove, GameMove cpuMove, string outcome)
    {
        return outcome switch
        {
            "Win" => GetWinMessage(playerMove, cpuMove),
            "Lose" => GetLoseMessage(playerMove, cpuMove),
            _ => $"{playerMove} vs {cpuMove} - It's a Draw!"
        };
    }
    // Specific win messages
    private string GetWinMessage(GameMove playerMove, GameMove cpuMove)
    {
        return (playerMove, cpuMove) switch
        {
            (GameMove.Rock, GameMove.Scissors) => "Rock crushes Scissors - You Win!",
            (GameMove.Rock, GameMove.Lizard) => "Rock crushes Lizard - You Win!",
            (GameMove.Paper, GameMove.Rock) => "Paper covers Rock - You Win!",
            (GameMove.Paper, GameMove.Spock) => "Paper disproves Spock - You Win!",
            (GameMove.Scissors, GameMove.Paper) => "Scissors cuts Paper - You Win!",
            (GameMove.Scissors, GameMove.Lizard) => "Scissors decapitates Lizard - You Win!",
            (GameMove.Lizard, GameMove.Paper) => "Lizard eats Paper - You Win!",
            (GameMove.Lizard, GameMove.Spock) => "Lizard poisons Spock - You Win!",
            (GameMove.Spock, GameMove.Scissors) => "Spock smashes Scissors - You Win!",
            (GameMove.Spock, GameMove.Rock) => "Spock vaporizes Rock - You Win!",
            _ => "You Win!"
        };
    }
    // Specific lose messages
    private string GetLoseMessage(GameMove playerMove, GameMove cpuMove)
    {
        return (playerMove, cpuMove) switch
        {
            (GameMove.Rock, GameMove.Paper) => "Paper covers Rock - CPU Wins!",
            (GameMove.Rock, GameMove.Spock) => "Spock vaporizes Rock - CPU Wins!",
            (GameMove.Paper, GameMove.Scissors) => "Scissors cuts Paper - CPU Wins!",
            (GameMove.Paper, GameMove.Lizard) => "Lizard eats Paper - CPU Wins!",
            (GameMove.Scissors, GameMove.Rock) => "Rock crushes Scissors - CPU Wins!",
            (GameMove.Scissors, GameMove.Spock) => "Spock smashes Scissors - CPU Wins!",
            (GameMove.Lizard, GameMove.Rock) => "Rock crushes Lizard - CPU Wins!",
            (GameMove.Lizard, GameMove.Scissors) => "Scissors decapitates Lizard - CPU Wins!",
            (GameMove.Spock, GameMove.Paper) => "Paper disproves Spock - CPU Wins!",
            (GameMove.Spock, GameMove.Lizard) => "Lizard poisons Spock - CPU Wins!",
            _ => "CPU Wins!"
        };
    }
}
