namespace HeroArchitect.Web.Domain.State;

public class StateContainer : IStateContainer
{
	private List<Game> _games = new List<Game>();

	public IReadOnlyCollection<Game> Games { get { return _games; } }


	private List<Lobby> _lobbies = new List<Lobby>();
	public IReadOnlyCollection<Lobby> Lobbies { get { return _lobbies; } }

	public Lobby CreateLobby(string name, int maxPlayer)
	{
		var lobby = new Lobby(Guid.NewGuid(), name, maxPlayer);
		_lobbies.Add(lobby);

		return lobby;
	}

	public Lobby JoinLobby(Guid lobbyId, User user)
	{
		var lobby = Lobbies.FirstOrDefault(x => x.Id == lobbyId);

		if (lobby is null)
		{
			throw new ApplicationException($"Lobby with id {lobbyId} could not be found.");
		}

		lobby.JoinLobby(user);

		return lobby;
	}
}