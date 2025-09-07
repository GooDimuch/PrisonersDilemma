namespace PrisonersDilemma;

/// <summary>
/// Grudger (Friedman) - Cooperates until opponent defects once, then always defects
/// </summary>
public class GrudgerStrategy : Strategy
{
    public override StrategyEnum StrategyType => StrategyEnum.Grudger;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        // First move: cooperate
        if (previousRounds == null || previousRounds.Count == 0)
            return true;

        int opponentIndex = index == 0 ? 1 : 0;
        
        // Check if opponent has ever defected
        bool opponentEverDefected = previousRounds.Any(r => !r.Moves[opponentIndex]);
        
        // If opponent has ever defected, always defect from now on
        return !opponentEverDefected;
    }
}