namespace HeroArchitect.App.Domain;

public class Lobby
{
    public Lobby(Guid id, string name, int maxPlayers)
    {
        Id = id;
        Name = name;
        MaxPlayers = maxPlayers;
        _users = new List<User>();
    }

    public Guid Id { get; }

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

    public void StartGame()
    {
        //todo
    }
}