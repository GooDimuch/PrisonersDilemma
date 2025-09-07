namespace PrisonersDilemma;

public interface IHasPoints
{
    Dictionary<StrategyEnum, int> GetResults();
}