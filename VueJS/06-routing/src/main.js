import Vue from 'vue'
import './plugins/bootstrap-vue'
import App from './App.vue'
import router from './router' // This import the router const defined in: src/router/index.js

new Vue({
    el: '#app',
    router,
    render: h => h(App)
})