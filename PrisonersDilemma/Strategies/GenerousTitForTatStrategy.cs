namespace PrisonersDilemma;

/// <summary>
/// Generous Tit for Tat - Like Tit for Tat but occasionally forgives defection
/// </summary>
public class GenerousTitForTatStrategy : Strategy
{
    private readonly Random _random;
    private readonly double _forgivenessRate;

    public override StrategyEnum StrategyType => StrategyEnum.GenerousTitForTat;

    public GenerousTitForTatStrategy(double forgivenessRate = 0.1)
    {
        _random = new Random();
        _forgivenessRate = forgivenessRate;
    }

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        // First move: cooperate
        if (previousRounds == null || previousRounds.Count == 0)
            return true;

        var lastRound = previousRounds.Last();
        int opponentIndex = index == 0 ? 1 : 0;
        bool opponentLastMove = lastRound.Moves[opponentIndex];
        
        // If opponent cooperated, cooperate
        if (opponentLastMove)
            return true;
        
        // If opponent defected, occasionally forgive (cooperate anyway)
        return _random.NextDouble() < _forgivenessRate;
    }
}