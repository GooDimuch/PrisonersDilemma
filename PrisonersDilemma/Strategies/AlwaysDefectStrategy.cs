namespace PrisonersDilemma;

/// <summary>
/// Always defects (returns false)
/// </summary>
public class AlwaysDefectStrategy : Strategy
{
    public override StrategyEnum StrategyType => StrategyEnum.AlwaysDefect;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        return false; // Always defect
    }
}