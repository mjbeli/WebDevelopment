# 07-vuex

### 06.01 Setup & basics

Using a centalized state means use a shared memory, or store, that will have all the common data of our application. That central store can be accessed from any site of our application, every component is able to modify the data and others component will be able to read the data.


Installing vuex helper package:
```
npm install --save vuex
```

Typically, all the files relates to the central state will be in a folder called ```store```. The main file it's typically named as ```store.js```. Simple initialization of store in the JS file:

``` javascript
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
```

We need to register the exported instance of the store in our main Vue instance. That's the way Vue will detect and use the store instance that we've just defined in ```store.js```

> In main.js
``` javascript
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
```

And that's all, we can start using our central management store like this:

Modifying the central state from a component:
``` html
<script>
    export default {
        methods: {
            // $store it's a global object that will be accesible since we instantiated a vuex instance.
            // Remember counter it's a variable defined inside the state object of vuex instance (in store.js)
            increment() {
                this.$store.state.counter++; 
            },
            decrement() {
                this.$store.state.counter--;
            }
        }
    }
</script>
```

Reading the central state from a component:
``` html
<script>
    export default {
        computed: {
            counter(){
                return this.$store.state.counter;
            }
        }
    }
</script>
```