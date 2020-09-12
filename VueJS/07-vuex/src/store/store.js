// The 2 tools we'll need.
import Vue from 'vue';
import Vuex from 'vuex';

// Register vuex plugin
Vue.use(Vuex);

// Create new store instance and export it with a name. It receives an object.
export const store = new Vuex.Store({
    // Our store has a central state --> this name must be 'state' in order to vuex detect it.
    // Inside this object we can defined any variable we want to save in cental management.
    state: {
        counter: 0
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
            return state.counter + 'Clicks';
        }
    },
    mutations: {
        // All mutations are functions that receive the state of the store. This is doing by Vuex.
        increment: (state, payload) => {
            state.counter += payload;
        },
        decrement: state => {
            state.counter--;
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
        asyncIncrement: (context, payload) => {
            setTimeout(() => {
                context.commit('increment', payload.by);
            }, payload.duration);
        },
        asyncDecrement: context => {
            setTimeout(() => {
                context.commit('decrement');
            }, 1000);
        }
    }
});