const state = {
    counter: 0
};

const getters = {
    doubleCounter: state => {
        return state.counter * 2;
    },
    counter: state => {
        return state.counter;
    },
    stringCounter: state => {
        return state.counter + ' Clicks';
    }
};

const mutations = {
    increment: (state, payload) => {
        state.counter += payload;
    },
    decrement: state => {
        state.counter--;
    }
};

const actions = {
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
    }
};

export default {
    state,
    getters,
    mutations,
    actions
}