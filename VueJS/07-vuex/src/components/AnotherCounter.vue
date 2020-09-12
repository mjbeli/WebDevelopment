import { mapActions } from 'vuex';
<template>
    <div>
        <button class="btn btn-primary" @click="asyncIncrement({ by: 50, duration: 1000})">Increment</button>
        <button class="btn btn-primary" @click="asyncDecrement">Decrement</button>
    </div>
</template>

<script>
    import {mapActions} from 'vuex';

    export default {
        methods: { 
            ...mapActions([
                'asyncIncrement', 'asyncDecrement'
            ])
            /*
            ,increment() {
                // commit always refers to execute a mutation. The name of the mutation it's passed as string.
                this.$store.commit('increment');
            },
            decrement() {
                this.$store.commit('decrement');
            }
            */
        }
    }
</script>