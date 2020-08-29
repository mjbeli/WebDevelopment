<template>
    <div class="bg-success">
        <p>Server component.</p>
        <li class="list-group-item pointer" @click="serverSelected">
            Server #{{ server.id }}
        </li>
    </div>
</template>

<script>
    // This import has curly braces {} because we have export
    // the eventBus with a name in main.js --> export const eventBus = new Vue();
    import { eventBus } from '../main.js'; 

    export default {
        props: ['server'],
        methods: {
            serverSelected() {
                this.$emit('serverSelectedEvent', this.server); // This event is for the father Servers component.
                console.log('emiting global event: ' + this.server.id + ' ' + this.server.status);
                eventBus.$emit('globalSelectedEvent', this.server); // This event is global, every component listen will be fired
            }
        }
    }
</script>

<style scoped>
.pointer {
    cursor: pointer;
}
</style>
