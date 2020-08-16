import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { store } from './store/store-vuex'
import axios from "axios";


Vue.prototype.$http = axios; // now this.$http contains an instancie of axios, not vue-resource
Vue.config.productionTip = false

new Vue({
    router,
    store: store,
    render: function(h) { return h(App) }
}).$mount('#app')