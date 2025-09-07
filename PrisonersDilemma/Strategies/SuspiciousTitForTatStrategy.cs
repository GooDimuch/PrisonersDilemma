namespace PrisonersDilemma;

/// <summary>
/// Suspicious Tit for Tat - Like Tit for Tat but starts with defection
/// </summary>
public class SuspiciousTitForTatStrategy : Strategy
{
    public override StrategyEnum StrategyType => StrategyEnum.SuspiciousTitForTat;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        // First move: defect (suspicious)
        if (previousRounds == null || previousRounds.Count == 0)
            return false;

        var lastRound = previousRounds.Last();
        int opponentIndex = index == 0 ? 1 : 0;
        
        // Copy opponent's last move
        return lastRound.Moves[opponentIndex];
    }
}