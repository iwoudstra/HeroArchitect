import { defineStore } from 'pinia'
import { useRouter, type Router } from 'vue-router';
import { serverconnection } from '@/serverconnection';
import type { gameMessage } from '@/models/gameMessage';
import type { gameLobby } from '@/models/gameLobby';

function messageHandler(message: gameMessage): void {
    let lobby = lobbyStore();
    lobby.handleMessage(message);
}

export const lobbyStore = defineStore({
    id: 'lobby',
    state: () => {
        let conn = new serverconnection('lobby', messageHandler);
        conn.connect(() => {
            conn.action('GetState');
        });

        const router = useRouter();

        return {
            lobbies: new Map<string, gameLobby>(),
            currentLobbyId: null,
            connection: conn,
            router: router
        } as LobbyModel
    },
    getters: {
        currentLobby: (state) => state.lobbies.get(state.currentLobbyId ?? '') ?? null
    },
    actions: {
        handleMessage(message: gameMessage) {
            let func = (this as any)[message.type];
            func(message.message);
        },
        //callbacks
        stateChanged(lobbies: gameLobby[]) {
            for (let lobby of lobbies) {
                this.lobbies.set(lobby.id, lobby);
            }
        },
        lobbyChanged(lobby: gameLobby) {
            this.lobbies.set(lobby.id, lobby);
        },
        lobbyDeleted(lobbyId: string) {
            this.lobbies.delete(lobbyId);
        },
        lobbyJoined(lobby: gameLobby) {
            this.currentLobbyId = lobby.id;
            this.router.push({ name: 'lobby', params: { lobbyId: this.currentLobbyId } });
        },
        lobbyLeft(lobbyId: string) {
            if (this.currentLobbyId === lobbyId) {
                this.currentLobbyId = null;
            }
            this.router.push('/');
        },
        gameStarted(gameId: string) {
            
        },
        //actions
        joinLobby(id: string) {
            this.connection.action('JoinLobby', id);
        },
        leaveLobby(id: string) {
            this.connection.action('LeaveLobby', id);
        },
        kickUser(id: string, userId: string) {
            this.connection.action('KickUser', id, userId);
        },
        createLobby(name: string, maxPlayerCount: number) {
            this.connection.action('CreateLobby', name, maxPlayerCount);
        },
        startGame(id: string) {
            this.connection.action('StartGame', id);
        }
    }
});

export interface LobbyModel {
    lobbies: Map<string, gameLobby>;
    currentLobbyId: string | null;
    connection: serverconnection;
    router: Router;
}