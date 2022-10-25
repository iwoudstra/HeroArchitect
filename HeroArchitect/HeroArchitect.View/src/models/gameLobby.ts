import type { gameUser } from "./gameUser";

export interface gameLobby {
    id: string;
    hostUserId: string;
    name: string;
    users: gameUser[];
    maxPlayers: number;
}