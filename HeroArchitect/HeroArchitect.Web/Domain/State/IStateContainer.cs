
namespace HeroArchitect.Web.Domain.State
{
	public interface IStateContainer
	{
		IReadOnlyCollection<Game> Games { get; }
		IReadOnlyCollection<Lobby> Lobbies { get; }

		Lobby CreateLobby(Guid hostUserId, string name, int maxPlayer);
		Lobby JoinLobby(Guid lobbyId, User user);
		Lobby GetLobby(Guid id);
		Lobby? LeaveLobby(Guid lobbyId, User user);
		SessionState GetSessionState(string reference);
        SessionState Register(string playerId, string reference);
        Game CreateGame(Lobby lobby);
		Game GetGame(Guid id);
    }
}