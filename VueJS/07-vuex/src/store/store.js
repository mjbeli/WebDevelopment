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
    }
});