namespace PrisonersDilemma;

/// <summary>
/// Tit for Two Tats - Defects only after opponent defects twice in a row
/// More forgiving than regular Tit for Tat
/// </summary>
public class TitForTwoTatsStrategy : Strategy
{
    public override StrategyEnum StrategyType => StrategyEnum.TitForTwoTats;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        // First move: cooperate
        if (previousRounds == null || previousRounds.Count < 2)
            return true;

        int opponentIndex = index == 0 ? 1 : 0;
        
        // Check if opponent defected in last two rounds
        var lastTwoRounds = previousRounds.Skip(Math.Max(0, previousRounds.Count - 2)).ToList();
        bool defectedTwice = lastTwoRounds.All(r => !r.Moves[opponentIndex]);
        
        // Only defect if opponent defected twice in a row
        return !defectedTwice;
    }
}