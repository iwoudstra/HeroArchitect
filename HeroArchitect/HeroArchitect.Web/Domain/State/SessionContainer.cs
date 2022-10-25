namespace HeroArchitect.Web.Domain.State;

public class SessionContainer : ISessionContainer
{
    private readonly IStateContainer _stateContainer;

    public SessionContainer(IStateContainer stateContainer)
    {
        _stateContainer = stateContainer;
    }

    public SessionState State { get; private set; } = null!;


    public void RetrieveState(string reference)
    {
        State = _stateContainer.GetSessionState(reference);
    }

    public void Register(string playerId, string reference)
    {
        State = _stateContainer.Register(playerId, reference);
    }
}