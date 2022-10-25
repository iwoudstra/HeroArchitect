using HeroArchitect.Web.Domain.Events;
using HeroArchitect.Web.Domain.Exceptions;

namespace HeroArchitect.Web.Domain;

public class Game
{
    private Game(Guid id, List<Player> players)
    {
        Id = id;
        Players = players;
        CurrentPlayer = players.First();
    }

    private List<IEvent> _events = new();
    private GameEventHandler _gameEventHandler = new();

    public Guid Id { get; }
    public IReadOnlyCollection<Player> Players { get; }
    public IReadOnlyCollection<IEvent> Events => _events.AsReadOnly();

    public Player CurrentPlayer { get; private set; }
    public int Round { get; private set; }
    public int NextEventOrder => _events.Count + 1;

    public static Game StartGame(Lobby lobby)
    {
        var players = lobby.Users.Select(x => new Player(Guid.NewGuid(), x.Id, x.Name)).ToList();
        var game = new Game(Guid.NewGuid(), players);

        return game;
    }

    public Player GetPlayer(Guid playerId)
    {
        return Players.Single(x => x.Id == playerId);
    }

    public Player? GetNextTurnPlayer()
    {
        return Players.OrderBy(x => x.CurrentSpecialUnit).Where(x => x.CurrentSpecialUnit > CurrentPlayer.CurrentSpecialUnit).FirstOrDefault();
    }

    public void HandleEvent(IEvent _event)
    {
        if (!_gameEventHandler.IsAllowed(this, _event))
        {
            throw new GameException("todo boardgamexception.");
        }

        _gameEventHandler.Handle(this, _event);
    }
}