namespace PrisonersDilemma;

public class Tournament : IHasPoints
{
    public PointsCalculationSystem PointsCalculationSystem { get; }
    public List<StrategyEnum> Participants { get; }
    public int AmountOfRounds  { get; }
    private List<Match> _matches;
    private Dictionary<StrategyEnum, int> _points;

    public Tournament(PointsCalculationSystem pointsCalculationSystem, List<StrategyEnum> participants, int amountOfRounds)
    {
        PointsCalculationSystem = pointsCalculationSystem;
        Participants = participants;
        AmountOfRounds = amountOfRounds;
        _matches = new List<Match>();
    }

    public void Process()
    {
        _matches = CreateMatches();
        _matches.ForEach(ProcessMatch);
        CloseTournament();
    }

    public async Task ProcessMultitask()
    {
        _matches = CreateMatches();
        await Task.WhenAll(_matches.Select(match => Task.Run(() => ProcessMatch(match))));
        CloseTournament();
    }

    public Dictionary<StrategyEnum, int> GetResults() => _points;

    private List<Match> CreateMatches() =>
        Participants.SelectMany(_ => Participants, (participant1, participant2) =>
            new Match(PointsCalculationSystem, [participant1.CreateStrategy(), participant2.CreateStrategy()], AmountOfRounds)).ToList();

    private void CloseTournament() => _points = CalculatePoints();

    private Dictionary<StrategyEnum, int> CalculatePoints()
    {
        var dict = Participants.ToDictionary(participant => participant, _ => 0);
        var results = _matches.Select(match => match.GetResults());
        foreach (var result in results)
        {
            foreach (var participant in result.Keys)
            {
                dict[participant] += result[participant];
            }
        }

        return dict;
    }

    private void ProcessMatch(Match match) => match.Process();
}