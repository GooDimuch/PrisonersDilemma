namespace PrisonersDilemma;

/// <summary>
/// Adaptive Strategy - Starts with a probe sequence, then adapts based on opponent's behavior
/// </summary>
public class AdaptiveStrategy : Strategy
{
    private readonly bool[] _probeSequence = { true, true, true, true, true, false, false, false, false, false };
    private double _opponentCooperationRate = 0.5;

    public override StrategyEnum StrategyType => StrategyEnum.Adaptive;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        if (previousRounds == null || previousRounds.Count == 0)
            return _probeSequence[0];

        // During probe phase
        if (previousRounds.Count < _probeSequence.Length)
            return _probeSequence[previousRounds.Count];

        // Calculate opponent's cooperation rate
        int opponentIndex = index == 0 ? 1 : 0;
        int cooperationCount = previousRounds.Count(r => r.Moves[opponentIndex]);
        _opponentCooperationRate = (double)cooperationCount / previousRounds.Count;

        // Adapt strategy based on opponent's behavior
        if (_opponentCooperationRate > 0.8)
            return false; // Exploit cooperator
        else if (_opponentCooperationRate > 0.3)
            return true; // Cooperate with reasonable opponent
        else
            return false; // Defect against defector
    }
}