<template>
  <div class="hello">
    <!-- Without helpers:
      <button @click="incrementCounterBy2()">Sumo 2</button>
      <button @click="incrementCounterBy3()">Sumo 3</button>
      <p>{{showCounter}}</p> This use computed property
    -->

    <!-- With helpers: -->
    <button @click="asyncIncrement(2)">Sumo 2</button>
    <button @click="incrementCounter(3)">Sumo 3</button>
    <p>{{counter}}</p> <!-- This use mapState mapping -->

    <!-- Let's work with vuex module src/vuex-modules/tareas -->
    <div>
      <p v-for="(item, index) in tareasState" :key="index">{{item}}</p>
      <p>{{moduleCounter}}</p>
      <button @click="incrementModuleCounter(4)">Sumo 4</button>
      
    </div>
  </div>
</template>

<script>
// In order to use vuex helpers
import { mapState } from 'vuex'; 
import { mapMutations } from 'vuex'
import { mapActions } from 'vuex'

export default {
  name: 'Store',
  props: {
   
  },
  computed:{

    /*
    //This works fine, but try to do it with a helper.
    showCounter(){
      return this.$store.state.counter;
    },
    */
    ...mapState(['counter']), // --> this automatic map this.counter to this.$store.state.counter
    ...mapState('ModuleTareas', ['tareasState', 'moduleCounter']) // map modules in vuex, first parameter is the name of import namespace.
  },
  methods: {
    /*
    // This works fine, but let's use mapActions...
    incrementCounterBy2() {
      this.$store.dispatch('asyncIncrement', 2); // This is the way to invoke an action, with dispatch
    },
    */
    /*
    // This works fine, but it's a better option to fire dispatch a commit using mapMutations
    incrementCounterBy3(){
      this.$store.commit('incrementCounter', 3); // This is the way to invoke a mutation, with commit
    },
    */
    ...mapActions(['asyncIncrement']),     // maps this.asyncIncrement(p) to this.$store.dispatch('asyncIncrement', 2)
    ...mapMutations(['incrementCounter']),  // maps this.incrementCounter(p) to this.$store.commit('incrementCounter', p)
    ...mapMutations('ModuleTareas', ['incrementModuleCounter'])
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
