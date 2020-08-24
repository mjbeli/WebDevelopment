import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { store } from './store/store-vuex'
import axios from "axios";


Vue.prototype.$http = axios; // now this.$http contains an instancie of axios, not vue-resource
Vue.config.productionTip = false

// We can register a method globally using this way
import SampleComp from './00 Components/SampleComponent.vue' // we can use "SampleComp" or any other name because in the definition of our component we used 'export default'
Vue.component('mi-componente', SampleComp);

new Vue({
    el: '#app', // this line means this Vue instance exists inside the id='app' html tag
    /*
    To register a component locally in a Vue instance we can use 
    component: {
        'mi-componente': {
            data: function(){ bla bla bla},
            template: 'blablabla',
            methods: { blablabla }
        }
    }
    */
    router,
    store: store,
    render: function(h) { return h(App) }
}); // .$mount('#app') --> this can replace the element --> el: '#app'