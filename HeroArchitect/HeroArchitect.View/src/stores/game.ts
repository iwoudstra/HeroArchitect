import { defineStore } from 'pinia'
import { serverconnection } from '@/serverconnection';
import type { gameMessage } from '@/models/gameMessage';
import type { gameState } from '@/models/gameState';

function messageHandler(message: gameMessage): void {
    let game = gameStore();
    game.handleMessage(message);
}

export const gameStore = defineStore({
    id: 'lobby',
    state: () => {
        let conn = new serverconnection('game', messageHandler);
        conn.connect(() => {
            conn.action('GetState');
        });

        return {
            gameStates: new Map<string, gameState>(),
            connection: conn
        } as GameModel
    },
    getters: {
    },
    actions: {
        handleMessage(message: gameMessage) {
            let func = (this as any)[message.type];
            func(message.message);
        },
        //callbacks
        //actions
    }
});

export interface GameModel {
    gameStates: Map<string, gameState>;
    connection: serverconnection;
}