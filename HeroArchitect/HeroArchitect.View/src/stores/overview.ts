import { defineStore } from 'pinia'
import { serverconnection } from '@/serverconnection';
import type { gameMessage } from '@/models/gameMessage';
import type { gameUser } from '@/models/gameUser';

function messageHandler(message: gameMessage): void {
    let overview = overviewStore();
    overview.handleMessage(message);
}

export const overviewStore = defineStore({
    id: 'overview',
    state: () => {
        let conn = new serverconnection('overview', messageHandler);
        conn.connect(() => {
            conn.action('GetState');
        });

        console.log(conn);

        return {
            currentUser: {},
            connection: conn
        } as OverviewModel
    },
    actions: {
        handleMessage(message: gameMessage) {
            let func = (this as any)[message.type];
            func(message.message);
        },
        setName(newName: string) {
            console.log(newName);
            this.connection.action('SetName', newName);
        },
        stateChanged(user: gameUser) {
            this.currentUser = user;
        }
    }
});

export interface OverviewModel {
    currentUser: gameUser;
    connection: serverconnection;
}