namespace PrisonersDilemma;

public abstract class Strategy
{
    public abstract StrategyEnum StrategyType { get; }

    public abstract bool GetNextMove(List<Round> previousRounds, int index);

    public override string ToString() => GetType().Name;
}