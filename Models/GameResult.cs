namespace myapiP.Models;

public class GameResult
{
    public GameMove PlayerMove { get; set; }
    public GameMove CpuMove { get; set; }
    public string? Outcome { get; set; }
    public string? Message { get; set; }
}
