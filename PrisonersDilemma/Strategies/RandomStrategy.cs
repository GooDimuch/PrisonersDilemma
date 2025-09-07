namespace PrisonersDilemma;

/// <summary>
/// Makes random moves with 50% probability for each choice
/// </summary>
public class RandomStrategy : Strategy
{
    private readonly Random _random;
    private readonly double _cooperationProbability;

    public override StrategyEnum StrategyType => StrategyEnum.Random;

    public RandomStrategy(double cooperationProbability = 0.5)
    {
        _random = new Random();
        _cooperationProbability = cooperationProbability;
    }

    public override bool GetNextMove(List<Round> previousRounds, int index)
    {
        return _random.NextDouble() < _cooperationProbability;
    }
}