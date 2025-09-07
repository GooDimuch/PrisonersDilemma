namespace PrisonersDilemma;

public class Match : IHasPoints
{
    public List<Strategy> Participants;
    public List<Round> Rounds;
    private Dictionary<StrategyEnum, int> _points;
    private int _amountOfRounds;
    private PointsCalculationSystem _pointsCalculationSystem;

    public Match(PointsCalculationSystem pointsCalculationSystem, List<Strategy> participants, int amountOfRounds)
    {
        _pointsCalculationSystem = pointsCalculationSystem;
        _amountOfRounds = amountOfRounds;
        Participants = participants;
        Rounds = new List<Round>();
    }

    public void Process()
    {
        for (int i = 0; i < _amountOfRounds; i++) ProcessNextRound();
        CloseMatch();
    }

    public Dictionary<StrategyEnum, int> GetResults() => _points;

    private void ProcessNextRound()
    {
        var round = new Round();
        round.CloseRound(Participants.Select((participants, index) => participants.GetNextMove(Rounds, index)).ToList());
        Rounds.Add(round);
    }

    private void CloseMatch() => _points = CalculatePoints();

    private Dictionary<StrategyEnum, int> CalculatePoints()
    {
        var dict = new Dictionary<StrategyEnum, int>(Participants.Count);
        Participants.ForEach(participant => dict.TryAdd(participant.StrategyType, 0));
        foreach (var round in Rounds)
        {
            var pointsData = _pointsCalculationSystem.CalculatePoints(round);
            for (int i = 0; i < Participants.Count; i++)
            {
                dict[Participants[i].StrategyType] += pointsData[i];
            }
        }

        return dict;
    }
}