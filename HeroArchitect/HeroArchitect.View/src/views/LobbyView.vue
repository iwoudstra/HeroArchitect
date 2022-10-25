<script setup lang="ts">
import { lobbyStore } from '@/stores/lobby';
import { overviewStore } from '@/stores/overview';

const props = defineProps<{
    lobbyId: string
}>();

let overview = overviewStore();
let lobby = lobbyStore();

let lobbyObj = lobby.lobbies.get(props.lobbyId)!;
let isLobbyHost = lobbyObj.hostUserId === overview.currentUser.id;

function leaveLobby(): void {
    lobby.leaveLobby(props.lobbyId);
}
function showKickUser(userId: string) {
    return isLobbyHost && userId !== lobbyObj.hostUserId;
}
function kickUser(userId: string) {
    lobby.kickUser(lobbyObj.id, userId);
}
function showStartGame() {
    return isLobbyHost;
}
function startGame() {
    lobby.startGame(lobbyObj.id);
}
</script>

<template>
    <main>
        <h1>Lobby {{ lobbyObj.name }}</h1>
        <button @click="leaveLobby()">Leave</button>
        <button
            v-if="showStartGame()"
            @click="startGame()"
        >Start game</button>

        <h2>Players</h2>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="player in lobbyObj.users">
                    <td>{{ player.name }}</td>
                    <td>
                        <button
                            v-if="showKickUser(player.id)"
                            @click="kickUser(player.id)"
                        >Kick</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </main>
</template>