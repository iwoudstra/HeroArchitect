import { HubConnectionBuilder } from '@microsoft/signalr';
import type { gameMessage } from './models/gameMessage';

export class serverconnection {
    connection: signalR.HubConnection;
    messageHandler: (message: gameMessage) => void;

    constructor(hubUrl: string, messageHandler: (message: gameMessage) => void) {
        this.connection = new HubConnectionBuilder().withUrl('https://localhost:7085/' + hubUrl).build();
        this.messageHandler = messageHandler;
    }

    connect(afterConnect: () => void): void {
        this.connection.on('ReceiveMessage', (message: gameMessage) => {
            this.messageHandler(message);
        });

        this.connection.start().then(() => {
            afterConnect();
        }).catch(function (err) {
            console.error('signalr connection error', err);
        });

        this.connection.onclose((error) => {
            console.log('disconnected', error);
        })
    }

    action(method: string, ...args: any[]) {
        this.connection.invoke(method, ...args);
    }
}