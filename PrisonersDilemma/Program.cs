using PrisonersDilemma;

List<StrategyEnum> participants =
[
    StrategyEnum.Adaptive, StrategyEnum.AlwaysCooperate, StrategyEnum.AlwaysDefect, StrategyEnum.Detective,
    StrategyEnum.GenerousTitForTat, StrategyEnum.Gradual, StrategyEnum.Grudger, StrategyEnum.Pavlov,
    StrategyEnum.Random, StrategyEnum.SuspiciousTitForTat, StrategyEnum.TitForTat, StrategyEnum.TitForTwoTats
];

for (int i = 0; i < 10; i++)
{
    var tournament = new Tournament(new ClassicPrisonersDilemmaPointsSystem(), participants, 200);
#if USE_MULTIPROCESSING
    await tournament.ProcessMultitask();
#else
    tournament.Process();
#endif
    var results = tournament.GetResults().ToList().OrderByDescending(pair => pair.Value).ToList();
    Console.WriteLine(string.Join('\n', results.Select(pair => $"{pair.Key} --- {pair.Value}")));
    Console.WriteLine();
}