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

export const eventBus = new Vue(); // Another Vue instance only to provide a event bus.

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
    render: h => h(App) /* See Note 1 down */
}); // .$mount('#app') --> this can replace the element --> el: '#app'

/*
Note 1: this is render function, tells to Vuejs take the element specifed in 'el' property
 and put the result of the arrow function (ES6). 'h' is the argument, it's seems to be a function. 
 This function is generated by Vuejs and takes the template as parameter that will be rendered.
 The template it's the one that it's in file App.vue --> import App from './App.vue'
 The template here it isn't defined as string, instead it's a compile template.
*/
/*
Two other ways to load App.vue file both needs babel-preset-stage-2 as a Dependency
npm install --save-dev babel-preset-stage-2

 1 - ES6 spread operator:
    import Vue from 'vue'
    import App from './App.vue'
     
    new Vue({
      el: '#app',
      ...App
    });

 2 - unsing mount:
    import Vue from 'vue'
    import App from './App.vue'
     
    const vm = new Vue({
      ...App
    });
     
    vm.$mount('#app');
*/