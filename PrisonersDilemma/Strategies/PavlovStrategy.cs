namespace PrisonersDilemma;

/// <summary>
/// Pavlov (Win-Stay, Lose-Shift) - Repeats last move if it resulted in good outcome
/// Changes move if it resulted in bad outcome
/// </summary>
public class PavlovStrategy : Strategy
{
    public override StrategyEnum StrategyType => StrategyEnum.Pavlov;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        // First move: cooperate
        if (previousRounds == null || previousRounds.Count == 0)
            return true;

        var lastRound = previousRounds.Last();
        int opponentIndex = index == 0 ? 1 : 0;
        
        bool myLastMove = lastRound.Moves[index];
        bool opponentLastMove = lastRound.Moves[opponentIndex];
        
        // Good outcomes: both cooperated (3,3) or I defected while opponent cooperated (5,0)
        // Bad outcomes: both defected (1,1) or I cooperated while opponent defected (0,5)
        
        if (myLastMove && opponentLastMove) // Both cooperated - good
            return true; // Stay with cooperation
        else if (!myLastMove && opponentLastMove) // I defected, opponent cooperated - good
            return false; // Stay with defection
        else if (myLastMove && !opponentLastMove) // I cooperated, opponent defected - bad
            return false; // Shift to defection
        else // Both defected - bad
            return true; // Shift to cooperation
    }
}