﻿using HeroArchitect.App.Domain;

namespace HeroArchitect.App.Domain.State
{
    public interface IStateContainer
    {
        IReadOnlyCollection<Game> Games { get; }
        IReadOnlyCollection<Lobby> Lobbies { get; }

        public Lobby CreateLobby(string name, int maxPlayer);
        public Lobby JoinLobby(Guid lobbyId, User user);
        public Lobby GetLobby(Guid id);
    }
}