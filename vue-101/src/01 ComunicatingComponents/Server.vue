<template>
    <li class="list-group-item pointer" @click="serverSelected">
        Server #{{ server.id }}
    </li>
</template>

<script>
    // This import has curly braces {} because we have export
    // the eventBus with a name in main.js --> export const eventBus = new Vue();
    import { eventBus } from '../main.js'; 

    export default {
        props: ['server'],
        methods: {
            serverSelected() {
                this.$emit('serverSelected', this.server);
                eventBus.$emit('serverSelected', this.server);
            }
        }
    }
</script>

<style scoped>
.pointer {
    cursor: pointer;
}
</style>
