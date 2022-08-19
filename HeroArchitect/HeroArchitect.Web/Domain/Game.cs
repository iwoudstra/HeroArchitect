using HeroArchitect.Web.Domain.Events;

namespace HeroArchitect.Web.Domain;

public class Game
{
    public Game(Guid id, List<Player> players)
    {
        Id = id;
        Players = players;
        CurrentPlayer = players.First();
    }

    private List<IEvent> _events= new();

    public Guid Id { get; }
    public IReadOnlyCollection<Player> Players { get; }
    public IReadOnlyCollection<IEvent> Events => _events.AsReadOnly();
    public Player CurrentPlayer { get; private set; }
    public int Round { get; private set; }
    public int NextEventOrder => _events.Count + 1;

    public Player? GetNextTurnPlayer()
    {
        return Players.OrderBy(x => x.CurrentSpecialUnit).Where(x => x.CurrentSpecialUnit > CurrentPlayer.CurrentSpecialUnit).FirstOrDefault();
    }

    public void HandleEvent(IEvent _event)
    {

    }
}