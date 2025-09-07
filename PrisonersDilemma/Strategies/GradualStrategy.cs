namespace PrisonersDilemma;

/// <summary>
/// Gradual - Cooperates until opponent defects, then punishes with increasing severity
/// but returns to cooperation after punishment
/// </summary>
public class GradualStrategy : Strategy
{
    private int _defectionCount = 0;
    private int _punishmentRemaining = 0;
    private int _calmDownRemaining = 0;

    public override StrategyEnum StrategyType => StrategyEnum.Gradual;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        // First move: cooperate
        if (previousRounds == null || previousRounds.Count == 0)
            return true;

        int opponentIndex = index == 0 ? 1 : 0;

        // If in calm down phase after punishment
        if (_calmDownRemaining > 0)
        {
            _calmDownRemaining--;
            return true;
        }

        // If currently punishing
        if (_punishmentRemaining > 0)
        {
            _punishmentRemaining--;
            if (_punishmentRemaining == 0)
                _calmDownRemaining = 2; // Two cooperation moves after punishment
            return false;
        }

        // Check if opponent defected last round
        var lastRound = previousRounds.Last();
        if (!lastRound.Moves[opponentIndex])
        {
            _defectionCount++;
            _punishmentRemaining = _defectionCount; // Punish for n rounds where n is total defections
            return false;
        }

        return true;
    }
}