namespace PrisonersDilemma;

public abstract class PointsCalculationSystem
{
    public abstract List<int> CalculatePoints(Round round);
}

public class ClassicPrisonersDilemmaPointsSystem : PointsCalculationSystem
{
    // Predefined payoff matrix: (Player1Move, Player2Move) -> [Player1Points, Player2Points]
    // true = Cooperate, false = Defect
    private static readonly Dictionary<(bool, bool), List<int>> PayoffMatrix = new()
    {
        { (true, true), [3, 3] }, // Both cooperate (Reward)
        { (true, false), [0, 5] }, // P1 cooperates, P2 defects (Sucker, Temptation)
        { (false, true), [5, 0] }, // P1 defects, P2 cooperates (Temptation, Sucker)
        { (false, false), [1, 1] } // Both defect (Punishment)
    };

    public override List<int> CalculatePoints(Round round)
    {
        // Validate that we have exactly 2 players
        if (round.Moves == null)
        {
            throw new ArgumentException("Round moves cannot be null");
        }

        if (round.Moves.Count != 2)
        {
            throw new ArgumentException(
                $"Classic Prisoner's Dilemma requires exactly 2 players, but {round.Moves.Count} were provided");
        }

        // Simple lookup in the payoff matrix
        var moveKey = (round.Moves[0], round.Moves[1]);
        return new List<int>(PayoffMatrix[moveKey]); // Return a copy to avoid external modifications
    }
}