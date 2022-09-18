<script setup lang="ts">
import { lobbyStore } from '@/stores/lobby';
import { overviewStore } from '@/stores/overview';
import { ref } from 'vue';

let overview = overviewStore();
let lobby = lobbyStore();
let userName = ref(overview.currentUser.name);
let lobbyName = ref('');
let lobbyMaxPlayerCount = ref(4);

function changeName(): void {
    overview.setName(userName.value);
}
function joinLobby(id: string): void {
    lobby.joinLobby(id);
}
function createLobby(): void {
    lobby.createLobby(lobbyName.value, lobbyMaxPlayerCount.value);
}
</script>

<template>
    <main>
        <h1>Hello {{ overview.currentUser.name }}</h1>

        <form action="javascript:void(0)">
            <label>Name:</label>
            <input
                type="text"
                v-model="userName"
            />

            <button @click="changeName">Change name</button>
        </form>

        <h2>Lobbies</h2>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Players</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <input
                            type="text"
                            v-model="lobbyName"
                        />
                    </td>
                    <td>
                        <input
                            type="number"
                            v-model="lobbyMaxPlayerCount"
                        />
                    </td>
                    <td>
                        <button @click="createLobby">Create lobby</button>
                    </td>
                </tr>
                <tr v-for="lob in lobby.lobbies.values()">
                    <td>{{ lob.name }}</td>
                    <td>{{ lob.users.length }} / {{ lob.maxPlayers }}</td>
                    <td><button @click="joinLobby(lob.id)">Join</button></td>
                </tr>
            </tbody>
        </table>
    </main>
</template>