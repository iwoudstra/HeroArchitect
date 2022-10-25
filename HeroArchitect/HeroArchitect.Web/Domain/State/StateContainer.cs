using HeroArchitect.Web.Domain.Exceptions;
using System.Collections.Concurrent;

namespace HeroArchitect.Web.Domain.State;

public class StateContainer : IStateContainer
{
    private ConcurrentDictionary<string, string> playerIds = new ConcurrentDictionary<string, string>();
    private ConcurrentDictionary<string, SessionState> _sessions = new ConcurrentDictionary<string, SessionState>();

    private List<Game> _games = new List<Game>();

    public IReadOnlyCollection<Game> Games { get { return _games; } }


    private List<Lobby> _lobbies = new List<Lobby>();
    public IReadOnlyCollection<Lobby> Lobbies { get { return _lobbies; } }

    public Lobby CreateLobby(Guid hostUserId, string name, int maxPlayer)
    {
        var lobby = new Lobby(Guid.NewGuid(), hostUserId, name, maxPlayer);
        _lobbies.Add(lobby);

        return lobby;
    }

    public Lobby JoinLobby(Guid lobbyId, User user)
    {
        var lobby = Lobbies.FirstOrDefault(x => x.Id == lobbyId);

        if (lobby is null)
        {
            throw new GameException($"Lobby with id {lobbyId} could not be found.");
        }

        lobby.JoinLobby(user);

        return lobby;
    }

    public Lobby GetLobby(Guid id)
    {
        return _lobbies.FirstOrDefault(x => x.Id == id) ?? throw new ApplicationException($"Lobby with id {id} not found!");
    }

    public Lobby? LeaveLobby(Guid lobbyId, User user)
    {
        var lobby = Lobbies.FirstOrDefault(x => x.Id == lobbyId);

        if (lobby is not null)
        {
            if (lobby.HostUserId == user.Id)
            {
                _lobbies.Remove(lobby);
                return null;
            }
            else if (lobby.Users.Any(x => x.Id == user.Id))
            {
                lobby.LeaveLobby(user);
                return lobby;
            }
        }

        throw new ApplicationException($"User with id {user.Id} is not in lobby {lobbyId}");
    }

    public SessionState GetSessionState(string reference)
    {
        if (!playerIds.ContainsKey(reference))
        {
            throw new GameException("Player not registered!");
        }

        var playerId = playerIds[reference];
        return _sessions[playerId];
    }

    public SessionState Register(string playerId, string reference)
    {
        playerIds[reference] = playerId;

        if (!_sessions.ContainsKey(playerId))
        {
            _sessions[playerId] = new SessionState();
        }

        return _sessions[playerId];
    }

    public Game CreateGame(Lobby lobby)
    {
        var game = lobby.StartGame();

        _games.Add(game);

        return game;
    }

    public Game GetGame(Guid id)
    {
        return _games.FirstOrDefault(x => x.Id == id) ?? throw new ApplicationException($"Game with id {id} not found!");
    }
}