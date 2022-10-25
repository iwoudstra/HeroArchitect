namespace HeroArchitect.Web.Domain.State
{
    public interface ISessionContainer
    {
        SessionState State { get; }

        void RetrieveState(string reference);
        void Register(string playerId, string reference);
    }
}