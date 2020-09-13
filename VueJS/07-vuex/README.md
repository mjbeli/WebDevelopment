# 07-vuex

### 07.01 Setup & basics

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
                // Actually it's not a good idea directly access to state.
                // It's a best solution use a mutation or action for modify the state.
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
                // Actually it's not a good idea directly access to state, it's a best solution use a getter.
                return this.$store.state.counter; 
            }
        }
    }
</script>
```

### 07.02 Getters

The getters are used to get a state from the store, perfom any operation or calculation and return the result. The idea is to put the shared code to access a state in a getter and then use that getter in differents components.

> In store.js
```javascript
export const store = new Vuex.Store({    
    state: { counter: 0 },
    getters: { // All getters are functions that automatically receive the state of the store. This is doing by Vuex.
        doubleCounter: state => {
            return state.counter * 2;
        },
        counter: state => {
            return state.counter;
        }
    }
});
```

This is how we access to the getters from a component:

```javascript
<script>
    export default {
        computed: {
            counter(){
                return this.$store.getters.doubleCounter;
            }
        }
    }
</script>
```

#### 07.02.01 Helpers for Getters

It's possible that if we have a lot of states and a lot of getters the code start to growing so fast in our component like this:
```javascript
<script>
    export default {
        computed: {
            counter(){
                return this.$store.getters.counter;
            },
            doubleCounter(){
                return this.$store.getters.doubleCounter;
            },
            clicks(){
                return this.$store.getters.stringCounter;
            }
        }
    }
</script>
```

A way to Vuex automatic map the getters with computed properties are using helpers:

>In our component
```javascript
<script>
    import { mapGetters } from 'vuex'; // Stablished name by Vuex

    export default {
        // Now instead of splicity write our computed properties we can
        computed: {
            // mapGetters is a function that receives an array. This array specify the getters we want use in this component.
            ...mapGetters([
                'doubleCounter', // automatic mapping
                myStringCounter: 'stringCounter', // explicit mapping
                'counter'
            ]),
            myOwnComputedProperty(){ // Using spread operator(ES6) we can combine mapGetters with our computed properties
                // ... some code
            }
        }
    }
</script>
```

*Important!* In case we have the typical error of unexpected token for spread operator, that's because the ES6 compiler that we are using here don't recognize the spread operator. The compiler from ES5 to ES6 is usually spicified in the package.json, in this case we are using babel and this preset don't recognize spread operator:
```
"devDependencies": {
    "babel-preset-es2015": "^6.0.0",
    ...
```

We can install this in our dev dependencies (at the end in production mode all will get compile to ES5, so we only need this in dev mode):
```
npm install --save-dev babel-preset-stage-2
```
After that add the new preset to -babelrc file:
```
{
    "presets": [
        ["es2015", {"modules": false}],
        ["stage-2"]
    ]
}
```

### 07.03 Mutations

When we have several components that can change the central state it can be difficult to tack wich component do a change, and again, it's probably that we must repeate the same code in diferent components if the change implies logic operation.

The mutations are here to help us setting the state of our store. The mutations are commited to the state and vuex it's the responsible to comunicate to all the components listening through the getters.

> In store.js
```javascript
export const store = new Vuex.Store({    
    state: {
       // ... some code
    },
    getters: {
        // ... some code
    },
    mutations: {
        // All mutations are functions that receive the state of the store. This is doing by Vuex.
        increment: state => {
            state.counter++;
        }
    }
});
```

To use mutations from components, call them from methods:
```javascript
<script>
    export default {
        methods: {            
            increment() {
                // commit always refers to execute a mutation. The name of the mutation it's passed as string.
                this.$store.commit('increment');
            },
            decrement() {
                this.$store.commit('decrement');
            }
        }
    }
</script>
```

Use helpers to avoid repeating code!
```javascript
<script>
    import { mapMutations } from 'vuex';

    export default {
        methods: {
            // mapMutations receive as argument an array with the names of the mutations we want to use in the component.
            ...mapMutations(
                ['increment', 'decrement'] // now we can use this.increment() or increment like a method in our component
            ),
            MyCustomMethod(){
                // ... some code
            }
        }
    }
</script>
```

*Important* Mutations are synchronous, always change the state instantly. So if we want an async operation (like reach the server), we must use Actions!

### 07.04 Actions

Actions are asynchronous. It's an extra piece that can run asynchronous task and then execute a mutation to change the state. We only commit the mutation once the async task it's done, so the changes in our state happen synchronously but we can perform asnc task before doing the change.

>In the store.js

```javascript
export const store = new Vuex.Store({
    state: {
        //
    },
    getters: {
        //
    },
    mutations: {
        increment: state => { state.counter++; },
        decrement: state => { state.counter--; }
    },
    actions: {
        // All actions are functions that receive the context. This is doing by Vuex.
        increment: context => {
            // ... do some async task
            // context gives us access to commit method, it isn't the same as state object but it's gives us
            // access to getter, commit... 
            context.commit('increment');
        },
        asyncIncrement: context => {
            setTimeout(() => {
                context.commit('increment');
            }, 2000);
        }
    }
});
```

Using actions:
```javascript
<script>    
    import { mapActions } from 'vuex';

    export default {
        methods: {           
           ...mapActions(['increment', 'decrement']),
           //,increment(){ this.store.dispatch('increment');},
           //,decrement(){ this.store.dispatch('decrement');},
            MyCustomMethod(){
                // ... some code
            }
        }
    }
</script>
```

### 07.05 Arguments to Mutations & Actions

In our termplate
```html
<button class="btn btn-primary" @click="increment(100)">Increment</button>
```

Using mapActions to call the dispatch with parameters won't change anythig:
```javascript
    ...mapActions(['increment', 'decrement'])
```

Calling directly an action with a paramenter:
```javascript
    // inside methods
    increment(by){
        this.$store.dispatch('increment', by);
    }
```

In the store.js will receive another argument:
```javascript
mutations: {
    increment: (state, payload) => {
        state.counter += payload;
    }
},
actions: {        
    increment: (context, payload) => {
        // ... do some async task
        context.commit('increment', payload);
    }
}
```

*Important* payload can be an object so we can pass inside more than one argument

```html
<button class="btn btn-primary" @click="asyncIncrement({ by: 50, duration: 2000})">Increment</button>
```
Using mapActions to call the dispatch with parameters won't change anythig:
```javascript
    ...mapActions(['asyncIncrement', 'asyncDecrement'])
```

Calling directly an action with a paramenter:
```javascript
    // inside methods
    increment(by){
        this.$store.dispatch('increment', payload);
    }
```

```javascript
actions: {
    asyncIncrement: (context, payload) => {
        setTimeout(() => {
            context.commit('increment', payload.by);
        }, payload.duration);
    }
}
```

### 07.06 v-model with cental state

In case we want to stablish a double binding (v-model) on a variable that it's in central vuex state, only a computed property won't work because the default behaviour of computed properties is return values. We must define the getter and the setter for the computed property as shown bellow:

```html
    <!--computed properties only returns a value, for use v-model the computed property must have set (in addition to traditional get) -->
    <input type="text" v-model="computedValue">
```

```javascript
computed: {
    computedValue: { // computed property with setter and getter is an object, not a function.
        get(){
            return this.$store.getters.value; // normal usage of a computed property.
        },
        set(value){
            this.$store.dispatch('updateValue', value); // setter for modify the central state of the application.
        }
    }
}
```

### 07.07 Patterns in store

#### 07.07.01 Modules

Modules is the way we can divide our central management store into different files, so we can maintain the different parts of our vuex store isolated. Actually, the central store reamins being unique, this technique allow us to divide the code.

> NEW File /store/modules/counter.js
```javascript
const state = {
    // Variables of state
};

const getters = {
    // Getters
};

const mutations = {
    // mutations
    increment: (state, payload) => {
        state.counter += payload;
    }
    // ...
};

const actions = {
    // Actions
    asyncIncrement: (context, payload) => { // With 1 parameter (max allowed)
        setTimeout(() => {
            context.commit('increment', payload.by);
        }, payload.duration);
    }
    // ...
};

// Only one export per file, export all variables we just defined.
export default { state, getters, mutations, actions }
```

Now we have to merge these variables with our central state.

> In store.js, where the vuex intance is defined:

```javascript
// Import modules like this:
import counter from './modules/counter';

export const store = new Vuex.Store({
    // state, getters, mutations, actions...

    // Modules imported
    ,modules {
        counter
    }
})
```
> Namespaces

It's important to keep in mind that we must remain the names of our store uniques. That's mean that the variable states, getters, mutations and actions must have an unique name.

For ensure that in large applications we can use namespaces so the names can duplicate if lives in different namespaces.

https://github.com/vuejs/vuex/releases/tag/v2.1.0


#### 07.07.02 Splitting central code

Another way to modularize our code it's to split the code of central store.js in different files. This isn't a logical split like in modules, we are talking here about take our central code that has no sense to encapsulate in a module and split it in different files.

> In file /store/getters.js

```javascript
export const value = state => {
    return state.value
}

export const anotherValue = state => {
    return state.anotherValue
}
// ...
```

> In file /store/mutations.js
```javascript
export const increment = (state, payload) => {
        state.counter += payload;
    }
}
// ...
```

And the same way we can create a file for actions, full of ```export const``` that will define a function with the code of our store.

In our instance of Vuex we can import these definitions this way:
> In /store/store.js
```javascript
import * as actions from './actions';
import * as getters from './getters';
import * as mutations from './mutations';

export const store = new Vuex.Store({   
    state: {
        counter: 0,
        value: 0
    },
    getters, // Here we are merging the code splitted in our 3 different files in our central store.
    mutations,
    actions

});
```

*Important* Of course, we can use this splitting technique in combination with modules.


