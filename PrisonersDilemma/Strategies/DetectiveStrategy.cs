namespace PrisonersDilemma;

/// <summary>
/// Detective - Starts with probe (C, D, C, C), then plays Tit for Tat if opponent cooperates,
/// or Always Defect if opponent always cooperates
/// </summary>
public class DetectiveStrategy : Strategy
{
    private readonly bool[] _probeSequence = { true, false, true, true };
    private bool _opponentIsNaive = true;

    public override StrategyEnum StrategyType => StrategyEnum.Detective;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        if (previousRounds == null || previousRounds.Count == 0)
            return _probeSequence[0];

        // During probe phase
        if (previousRounds.Count < _probeSequence.Length)
            return _probeSequence[previousRounds.Count];

        int opponentIndex = index == 0 ? 1 : 0;

        // After probe phase, check if opponent ever defected during probe
        if (previousRounds.Count == _probeSequence.Length)
        {
            _opponentIsNaive = previousRounds
                .Take(_probeSequence.Length)
                .All(r => r.Moves[opponentIndex]);
        }

        // If opponent is naive (always cooperated during probe), exploit them
        if (_opponentIsNaive)
            return false;

        // Otherwise, play Tit for Tat
        var lastRound = previousRounds.Last();
        return lastRound.Moves[opponentIndex];
    }
}