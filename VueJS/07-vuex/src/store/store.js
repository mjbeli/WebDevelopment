// The 2 tools we'll need.
import Vue from 'vue';
import Vuex from 'vuex';

// Import modules like this:
// import counter from './modules/counter';

// Register vuex plugin
Vue.use(Vuex);

// Create new store instance and export it with a name. It receives an object.
export const store = new Vuex.Store({
    // Our store has a central state --> this name must be 'state' in order to vuex detect it.
    // Inside this object we can defined any variable we want to save in cental management.
    state: {
        counter: 0,
        value: 0
    },
    getters: {
        // All getters are functions that receive the state of the store. This is doing by Vuex.
        doubleCounter: state => {
            return state.counter * 2;
        },
        counter: state => {
            return state.counter;
        },
        stringCounter: state => {
            return state.counter + ' Clicks';
        },
        value: state => {
            return state.value;
        }
    },
    mutations: {
        // All mutations are functions that receive the state of the store. This is doing by Vuex.
        increment: (state, payload) => {
            state.counter += payload;
        },
        decrement: state => {
            state.counter--;
        },
        updateValue: (state, payload) => {
            state.value = payload;
        }
    },
    actions: {
        // All actions are functions that receive the context. This is doing by Vuex.
        increment: (context, payload) => {
            // ... do some async task
            // context gives us access to commit method
            context.commit('increment', payload);
        },
        decrement: context => {
            context.commit('decrement');
        },
        asyncIncrement: (context, payload) => { // With 1 parameter (max allowed)
            setTimeout(() => {
                context.commit('increment', payload.by);
            }, payload.duration);
        },
        asyncDecrement: context => { // Without parameters
            setTimeout(() => {
                context.commit('decrement');
            }, 1000);
        },
        updateValue: (context, payload) => {
            context.commit('updateValue', payload);
        }
    }
    /*
    , modules {
        counter
    }
    */
});