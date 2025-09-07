namespace PrisonersDilemma;

/// <summary>
/// Tit for Tat - Cooperates on first move, then copies opponent's previous move
/// </summary>
public class TitForTatStrategy : Strategy
{
    public override StrategyEnum StrategyType => StrategyEnum.TitForTat;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        // First move: cooperate
        if (previousRounds == null || previousRounds.Count == 0)
            return true;

        // Get the last round
        var lastRound = previousRounds.Last();
        
        // Find opponent's index (assuming 2 players)
        int opponentIndex = index == 0 ? 1 : 0;
        
        // Copy opponent's last move
        return lastRound.Moves[opponentIndex];
    }
}