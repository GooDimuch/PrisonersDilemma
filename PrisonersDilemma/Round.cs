namespace PrisonersDilemma;

public struct Round
{
    public List<bool> Moves;
    public bool InProgress => Moves.IsNullOrEmpty();

    public void CloseRound(List<bool> moves)
    {
        Moves = moves;
    }
}