<template>
    <div class="col-xs-12 col-sm-6">
        <ul class="list-group">
            <app-server
                v-for="server in servers" :key="server.id"
                :server="server" @serverSelected="changeServer"></app-server>
        </ul>
        <p v-if="lastSelectedServer"> Last server selected: {{lastSelectedServer.id}}</p>
    </div>
</template>

<script>
    import Server from './Server.vue';

    export default {
        components: {
            appServer: Server
        },
        data: function() {
            return {
              servers: [
                  { id: 1, status: 'Normal'},
                  { id: 2, status: 'Critical'},
                  { id: 3, status: 'Unknown'},
                  { id: 4, status: 'Normal'}
              ],
              lastSelectedServer: null
            };
        },
        methods: {
            changeServer(server){
                this.lastSelectedServer = server;
            }
        }        
    }
</script>

<style>

</style>
