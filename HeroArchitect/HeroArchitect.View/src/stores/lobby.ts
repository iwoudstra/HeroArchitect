import { defineStore } from 'pinia'
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

        return {
            lobbies: new Map<string, gameLobby>(),
            currentLobbyId: null,
            connection: conn
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
        joinLobby(id: string) {
            this.connection.action('JoinLobby', id);
        },
        createLobby(name: string, maxPlayerCount: number) {
            this.connection.action('CreateLobby', name, maxPlayerCount);
        },
        stateChanged(lobbies: gameLobby[]) {
            for (let lobby of lobbies) {
                this.lobbies.set(lobby.id, lobby);
            }
        }
    }
});

export interface LobbyModel {
    lobbies: Map<string, gameLobby>;
    currentLobbyId: string | null;
    connection: serverconnection;
}