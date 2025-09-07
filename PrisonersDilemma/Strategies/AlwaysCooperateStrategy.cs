namespace PrisonersDilemma;

/// <summary>
/// Always cooperates (returns true)
/// </summary>
public class AlwaysCooperateStrategy : Strategy
{
    public override StrategyEnum StrategyType => StrategyEnum.AlwaysCooperate;

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        return true; // Always cooperate
    }
}