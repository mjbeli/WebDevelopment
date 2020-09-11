import Vue from 'vue'
import App from './App.vue'

// Import the store instance we've just created and exported in store.js
import { store } from './store/store';

// Register the store instance in the Vue instance as a property of Vue instance.
new Vue({
    el: '#app',
    store, // same as store: store,
    render: h => h(App)
})