<template>
  <div class="hello">
      <button @click="incrementCounterBy2()">Sumo 2</button>
      <button @click="incrementCounterBy3()">Sumo 3</button>

      <p>{{showCounter}}</p>
  </div>
</template>

<script>
export default {
  name: 'Store',
  props: {
   
  },
  computed:{
    showCounter(){
      return this.$store.state.counter;
    }
  },
  methods: {
    incrementCounterBy2() {
      this.$store.dispatch('asyncIncrement', 2); // This is the way to invoke an action, with dispatch
    },
    incrementCounterBy3(){
      this.$store.commit('incrementCounter', 3); // This is the way to invoke a mutation, with commit
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
a {
  color: #42b983;
}
</style>
