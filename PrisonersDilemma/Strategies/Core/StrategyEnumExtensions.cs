namespace PrisonersDilemma;

public static class StrategyEnumExtensions
{
    public static Strategy CreateStrategy(this StrategyEnum strategyEnum)
    {
        return strategyEnum switch
        {
            StrategyEnum.Adaptive => new AdaptiveStrategy(),
            StrategyEnum.AlwaysCooperate => new AlwaysCooperateStrategy(),
            StrategyEnum.AlwaysDefect => new AlwaysDefectStrategy(),
            StrategyEnum.Detective => new DetectiveStrategy(),
            StrategyEnum.GenerousTitForTat => new GenerousTitForTatStrategy(),
            StrategyEnum.Gradual => new GradualStrategy(),
            StrategyEnum.Grudger => new GrudgerStrategy(),
            StrategyEnum.Pavlov => new PavlovStrategy(),
            StrategyEnum.Random => new RandomStrategy(),
            StrategyEnum.SuspiciousTitForTat => new SuspiciousTitForTatStrategy(),
            StrategyEnum.TitForTat => new TitForTatStrategy(),
            StrategyEnum.TitForTwoTats => new TitForTwoTatsStrategy(),
            _ => throw new ArgumentOutOfRangeException(nameof(strategyEnum), strategyEnum, null)
        };
    }
}