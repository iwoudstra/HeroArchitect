namespace HeroArchitect.Web.Domain;

public class Lobby
{
    public Lobby(Guid id, Guid hostUserId, string name, int maxPlayers)
    {
        Id = id;
        HostUserId = hostUserId;
        Name = name;
        MaxPlayers = maxPlayers;
        _users = new List<User>();
    }

    public Guid Id { get; }

    public Guid HostUserId { get; }

    public string Name { get; }

    public int MaxPlayers { get; }

    private List<User> _users;
    public IReadOnlyCollection<User> Users { get { return _users; } }

    public Lobby JoinLobby(User user)
    {
        if (_users.Count >= MaxPlayers)
        {
            throw new ApplicationException($"Lobby is full already has {MaxPlayers} players.");
        }

        if (_users.Contains(user))
        {
            throw new ApplicationException($"User {user.Name} is already in this lobby.");
        }

        _users.Add(user);

        return this;
    }

    public void LeaveLobby(User user)
    {
        _users.Remove(user);
    }

    public Game StartGame()
    {
        return Game.StartGame(this);
    }

    public void KickUser(Guid userId)
    {
        _users.RemoveAll(x => x.Id == userId && x.Id != HostUserId);
    }
}