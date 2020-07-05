import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// In the component that uses this state, use computed for access getters 
// and methods to access mutations and actions (with dispatch).

/**************************
 * Sample of accessing to this store from a component:
computed: {
  value() {
    return this.$store.getters.value;
  }
},
methods: {
  increment() {
    this.$store.dispatch('increment', 2)
  }
} 
 */

export const store = new Vuex.Store({
    state: {
        counter: 0
    },
    getters: {
        getCounter: function() {
            return counter;
        },
        getTripleCounter: function(variable) {
            return (counter * 3) + variable;
        }
    },
    // Mutations are always synchronous.
    // Mutations are the only way to change the state.
    mutations: {
        incrementCounter: function(state, variable) { // Always receive state as first parameter.
            state.counter += variable;
        }
    },
    // Actions allow us to change the state in a asynchronous way.
    // Always use a commit to a mutation, due the mutations are the only way to change the state.
    actions: {
        asyncIncrement: function({ commit }, variable) {
            commit('incrementCounter', variable);
        }
    },
    modules: {}
})