# 02-components

### 02.01 Introduction

Components are reusable pieces of html with connected data and logic. This pieces can be reuses over the application or over the pages. Each data and logic of a instance it's independent from other intances. A component encapsulate structure, content and logic into small reusable pieces.

Inside our main.js file we can define and create the Vue application:

```javascript
// Importing an exported object with name 'createApp' from the Vue package.
// Note in package.json: "vue": "^3.0.0" dependency
import { createApp } from 'vue' 

// Here we are importing our first component from the file App.vue (using relative path) and
// because we use an export default in the App.vue file we are naming the component as "App"
import App from './App.vue' 

// Creating and mounting the Vue App in an html tag with id 'app' in the index .html file.
createApp(App).mount('#app')
```

As you can see in the .vue files, we've got 3 sections: template (html code), script (javascript) and styles (css) that encapsulate all the component behaviour, content and styling:

```vue
<template>
    <!-- In Vue 3 you can have more than one root element-->
    <!-- This html code will be injected in all sites where we use the component -->
  <h3>My agenda</h3>  
  <div></div>  
</template>

<script>
// Beause we are using an export default here we can put the name we choose when importing this component in other file.
// For example in main.js --> import CustomNameForThisComponent from './App.vue'
export default {
  name: 'App',
  data() {
    return {
      friends: [
        {
          id: 'aa',
          name: 'aa',
          telephone: '12345',
          email: 'aa@invent.com'
          }
      ]
    }
  }
}
</script>

<style>
</style>
```

Every component is like a small vue app, and in the script tag will expect the same config object like a vue app. Also, this is the object that we'll export to share the component, that why most cases start with `export default {};`. A main difference is that we don't specify the template inside the config object, but inside the template tag.

### 02.02 Using components

We can register an element globally in the `main.js` file this way:

```javascript
import { createApp } from 'vue';
import App from './App.vue';
import FriendContact from './components/FriendContact.vue';

const app = createApp(App);
app.component('friend-contact', FriendContact);
app.mount('#app');
```

Now we can use friend-contact component from any site of our application:
```vue
<template>
  <friend-contact> </friend-contact>     
</template>
```

But aso we can register the component locally in each component we want to use it:
```vue
<template>
  <friend-contact> </friend-contact>     
</template>
<script>
import FriendContact from './components/FriendContact.vue';

export default {
  name: 'App',
  components: { FriendContact }
  /**** some code */
}
</script>
```

### 02.03 Props

Props are the concept use to pass information to the child components. Are custom html attributes that you can add to the child components. To make a component aware of thats custom attributes we can define them into a new property in the config object called `props`.

The simplest way to define the props is using an array full of strings that define the name of the props.
```vue
<template>
  <!-- This html code will be injected in all sites where we use the component -->
  <div>
      <h4> {{ name }} </h4>      
      <ul v-if="detailsVisible">
          <li><strong>Phone:</strong> {{ phone }}</li>
          <li><strong>Email:</strong> {{ email }}</li>
      </ul>
  </div>  
</template>
<script>

export default {
    name: 'friend-contact',
    props: ['name', 'phone', 'email']
}
</script>
```
Now we can use the props as custom attributes we using the component:

```vue
<template>
  <friend-contact name="aaa" phone="1234" email="coas@sample.com" > </friend-contact>    
  <friend-contact name="bbb" phone="5667" email="dfsfs@sample.com" > </friend-contact> 
</template>
```

Remember not using the same variable name in props as in `data()` to avoid overlaping names.

Of course, you can binding the props to dinamic values using `v-bind` or `:`. Actually it's necessary to pass non string values as booleans or expresions:
```vue
<template>
  <friend-contact name="aaa" phone="1234" :isFavourite="true" > </friend-contact> 
</template>
```

*When using v-for on custom components it's mandatory to use the key attribute.*

#### 02.03.01 Mapping objects to props

If you have an object which holds the props you want to set as properties, you can also shorten the code a bit:

```vue
<template>
  <user-data v-bind="person"></user-data> <!-- user-data component has 2 props with name firstname and lastname -->
</template>     
<script>
  export default {
    data() {
      return { person: { firstname: 'Max', lastname: 'Schwarz' } };
    }
  }
</script>
```

With `v-bind` you pass all key-value pairs inside of an object as props to the component.


#### 02.03.02 Unidirectional data flow

*Important!* Props shouldn't be computed. That's because the props passing to a child component can't be directly modified by the child component, we have an error if we try to set a value to a prop. Instead of that we can send an event to the parent so it can change the prop (see bellow) or we can assign the prop to a variable in local `data(){}` and work with that data.
```vue
<script>
export default {    
    props: ['name', 'phone', 'email'],
    data(){
      localName: this.name
    },
    methods:{
      doSomethigFunction(){
        this.localName = 'settingValue'; // We can set the value of our local data variable.
      }
    }
}
</script>
```

#### 02.03.03 Validating props

To provide more information about props using by a component we can use alternatives ways of declaring it.

>Define all props as an object

Each key is the name of the prop and the value is the expected type of the prop.
```vue
<script>
export default {    
    props {
      name: String,
      age: Number,
      isFavourite: Boolean,
      Address: Object
    } 
}
</script>
```

>Define each prop as an object

Each prop can be defined as an object with different predefined attributes: `type` for the expected type, `required` to indicate if it's a mandatory prop (true or false), `default` to assign a value to non-required props, `validator` which holds a function returning a boolean that determines if the value it's valid or not.

```vue
<script>
export default {    
    props {
      name: {
        type: String,
        required: true
      },
      isFavourite: {
        type: Boolean,
        required: false,
        default: false // this can be a function(){ ... }
      }
    } 
}
</script>
```

### 02.04 Events to parent

Events are the way to comunicating the childs component to the parents. There's a method provided by Vue to emit events: `this.$emit()`. This allows you to emit custom events that the parent can subscribe to.

`$emit` recevibes at least one argument, that's the event name. But you can pass as many arguments as you want, the second argument can be data to identify the element itself (for example the id).
To listen the event in the parent, just use the `v-on` or `@` as just normal events, but instead listening click, load or any other typical events, you listen to your custom event, so use the defined name.

> In the child component, emiting the event
```vue
<template>
  <button @click="toggleFavourite"> Toggle Favourite </button>
</template>
<script>
export default {    
    /***/
    props: { id: { type: String, required: true } },
    methods: {
      toggleFavourite(){
            this.$emit('evt-toggle-favourite', this.id);
        }
    }
}
</script>
```

> In the parent component, listening the event
```vue
<template>
  <friend-contact v-for="friend in friends" 
                    :key="friend.id"                     
                    :id="friend.id"                     
                    :isFavourite="friend.isFavourite" 
                    @evt-toggle-favourite="changeFavourite" > </friend-contact>
</template>
<script>
export default {    
    /***/
    methods: {
      changeFavourite(friendId){
        console.log('change the favourite mark! ' + friendId);
        let myFriend = this.friends.find(friend => friend.id == friendId);
        myFriend.isFavourite = !myFriend.isFavourite;
      }
    }
}
</script>
```

#### 02.04.01 Documenting events

We can add a new entry to the config object to document our component. So other developers can see which events can emit a component without reading all the code searching for emits.

The basic form to declaring an event it's with an array `emits: ['evt-toggle-favourite']`, but just like props, we can define an event using objects where the key it's the event name and the value it's a function that receives the data emitting as paramter.

```vue
<script>
export default {    
    /***/
    emits: {
      // Here we're saying that this event should be handled by a function that receives an id.
      'evt-toggle-favourite': function(id) { 
          if(id) // this is a validation
              return true;
          else{
              console.warn('Id is missing');
              return false;
          }
      }
    }
    methods: {
      toggleFavourite(){
            this.$emit('evt-toggle-favourite', this.id);
        }
    }
}
</script>
```