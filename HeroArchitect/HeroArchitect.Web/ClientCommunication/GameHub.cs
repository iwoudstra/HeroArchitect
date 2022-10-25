using HeroArchitect.Web.Domain.State;

namespace HeroArchitect.Web.ClientCommunication;

public class GameHub : BaseHub
{
    public GameHub(IStateContainer stateContainer, ISessionContainer sessionContainer)
        : base(stateContainer, sessionContainer)
    {
    }

    public async Task JoinGame(Guid gameId)
    {
        var game = _stateContainer.GetLobby(gameId);

        await Groups.AddToGroupAsync(Context.ConnectionId, game.Id.ToString());
    }
}