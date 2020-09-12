<template>
    <div>
        <button class="btn btn-primary" @click="increment(100)">Increment</button>
        <button class="btn btn-primary" @click="decrement">Decrement</button>
    </div>
</template>

<script>
    //import { mapMutations } from 'vuex';
    import { mapActions } from 'vuex';


    export default {
        methods: {
            // mapMutations receive as argument an array with the names of the mutations we want to use in the component.
            /*
            ...mapMutations(
                ['increment', 'decrement']
            ) 
            */
           ...mapActions(['increment', 'decrement']),
            MyCustomMethod(){
                // ... some code
            }
            /* mapActions generate this code
            ,increment(by){
                this.$store.dispatch('increment', by);
            }
            */
            
        }
    }
</script>