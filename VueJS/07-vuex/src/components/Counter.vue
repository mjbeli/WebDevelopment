<template>
    <div>
        <button class="btn btn-primary" @click="increment">Increment</button>
        <button class="btn btn-primary" @click="decrement">Decrement</button>
    </div>
</template>

<script>
    export default {
        methods: {
            // $store it's a global object that will be accesible since we instantiated a vuex instance.
            increment() {
                this.$store.state.counter++; 
            },
            decrement() {
                this.$store.state.counter--;
            }
        }
    }
</script>