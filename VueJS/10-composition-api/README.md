# 10-composition-api

Ensure to get the lastes version of VueCLI with this command:
```
npm install -g @vue/cli
```

Then you can create a Vue3 project with VueCLI selecting it in the options:
```
vue create project-name
```

### 10.01 Introduction

The problem to intend to solve the composition API it's that in large applications the logic that it's related it's splitted into a component. The logic an be splitted into data, methods, computed and watchers,... with composition API we can merge together these four elements into one setup method, so all the logic can stay together.

```javascript
export default {
  props: { count: Number }, // props and components remains untouched.
  components: {},
  setup(props, context) {
    // here goes data, methods, computed and watchers...
  }
};
```

The template and style sections remains the same, the props, emits events, components also remains the same. The hooks looks differents!

*Important* Inside this new ```setup()``` function we cann't access to the typical Vue config object ```this.``` to access data, methods and so on. 

```setup()``` it's a function executed by Vue very early in the process. Even before the initialization of the component.


### 10.02 Reactive data

#### 10.02.01 ref

```ref``` it's a function we can call inside of ```setup()``` that creates a reactive object that Vue will manage. Actually, ref wrapped the variable into an object so we must work with them in a special way:
 - We can use the variables creates with ref into templates as the usual way after exposes them. Vue will automatically access to the value of the wrapped object.
 - We can use the variable into setup but accessing wto the value ```data.value```
 - Vue can watch the ref variable (not neccesary to watch the value).
 - Vue can create computed propertis from refs.

```setup()``` it's a function executed by Vue very early in the process. Even before the initialization of the component. Therefore, the data created must be stored in a typical variable or const vanilla javascript.

```javascript
import { ref } from 'vue'; // this is mandatory

export default {
  setup(){ // here goes data, methods, computed and watchers

    // ref creates a reactive variable, and stored it into a constant, we can pass the initial value as an argument.
    const usName = ref('Belizón');

    // if here we do somethig like usName = 'New name'; won't work because we are
    // destroying the reactive object! We need to work with usName.value so the reactive reamins
    // That's the reason because we declare a constant.
    setTimeout(() => {
        usName.value = 'New Name';
    }, 3000);

    // Every things we want to be available in the DOM (in our template section).
    // we need an extra step: return an object with all we want to expose to the template.
    // setup() always return an object:
    return {
        userName: usName // this exposes to the DOM a variable called 'userName' that it's usName inside setup() function.
    };
  }
};
```

We can access the value from the DOM this way:
```html
<template>
     <!-- In the template we don't need to acces to .value, Vue will access the .value automatically -->
    <h2>{{ userName }}</h2>
</template>
```

#### 10.02.02 ref & complex objects

Imagine we have a complex object we want to be reactive. It's important the way we exposes the object to the template so Vue can keep track of the changes.

```javascript
import { ref } from 'vue'; // this is mandatory

export default {
  setup(){ 
    const user = ref({ name: 'Belizón', age: 17 });

    // This is the correct way to change values of complex objects.
    // We access to the 'value' attribute, and thats the place where it's the object and it's differents attributes.
    setTimeout(() => {
        user.value.name = 'New Name';
        user.value.age = '18';
    }, 3000);
    
    return {
        // If we exposes attributes, we exposes somethings that aren't reactives, so the first
        // values are shared with template well but the changes will not be refreshed.
        // We are just exposing a string and integer that will not change.
        // userName: user.value.name, userAge: user.value.age  

        // remember the reactive object it's user, not it's attributes. Now Vue can track the changes
        // within user attributes
        user: user
    };
  }
};
```

In the template:
```html
<template>     
    <h2>{{ user.name }}</h2> <!-- user is reactive, so the changes in it's attributes will be updated in the DOM-->
    <h2>{{ user.age }}</h2>
</template>
```


#### 10.02.03 Reactive

Reactive function it's like ref (create a reative object) but with two main differences:
 - It only can be used with complex object (if you want a simple variable to be reactive you must use ref).
 - It hasn't the warp object, so you can access the attributes without accessing .value

Note we import the reactive function from Vue as earlier we imported ref.

```javascript
import { reactive } from 'vue'; // this is mandatory

export default {
  setup(){ 
    const user = reactive({ name: 'Belizón', age: 17 }); // reactive it's only for objects

    // With reactive we haven't to use user.value.name, all the object it's reactive and manage by Vue.
    setTimeout(() => {
        user.name = 'New Name';
        user.age = '18';
    }, 3000);
    
    return {
        // expose all the reactive object to the DOM, 
        // again if we exposes the attributes the Dom won't be updated with changes. Attributes aren't reactive!
        user: user
    };
  }
};
```

In the template:
```html
<template>     
    <h2>{{ user.name }}</h2> <!-- user is reactive, so the changes in it's attributes will be updated in the DOM-->
    <h2>{{ user.age }}</h2>
</template>
```

### 10.03 Methods

Just define the methods you want to invoke in the template inside setup(). The setup() function will only execute once and "register" the data (with ref or reactive), the same way we can register the methods.

```javascript
import { reactive } from 'vue'; // this is mandatory

export default {
  setup(){ 
    const user = reactive({ name: 'Belizón', age: 17 }); // reactive only for objects

    function setNewAge(){
      user.age= 22;
    }

    return {        
        user, // exposes the object as reactive.
        setAge: setNewAge // exposes the function the same way we exposes the data, this is a pointer to the function.
    }; 
    };
  }
};
```
In the template:
```html
<template>     
    <h2>{{ user.name }}</h2> 
    <h2>{{ user.age }}</h2>
    <button @click.prevent="setAge">change age</button>
</template>
```

We can use functions with ref variables like this:
```javascript
import { ref } from 'vue'; // this is mandatory

export default {
  setup(){ 
    const usName = ref('Belizón'); 

    function setNewName(){
      usName.value= 'MyNewNewName';
    }

    return {        
        userName: usName,
        SetNewName
    }; 
  }
};
```
```html
<template>     
    <h2>{{ userName }}</h2> 
    <button @click.prevent="SetNewName">change Name</button>
</template>
```
### 10.04 v-model in composition API

v-model accepts ref and reactives variables, just remember to exposes it.
```javascript
import { ref } from 'vue'; 

export default {
  setup(){         
    const firstName = ref('');
    const secondName = ref('');
    
    return {        
        firstName, secondName
    }; 
  }
};
```
```html
<div>
  <input type="text" placeholder="First Name" v-model="firstName"> <!--remember don't use .value in templates-->
  <input type="text" placeholder="Last Name" v-model="secondName"> 
</div>
```

### 10.05 Computed properties

```javascript
import { ref, computed } from 'vue'; // this is mandatory

export default {
  setup(){         
    const firstName = ref('');
    const secondName = ref('');    

    // Call computed function that receives a function as an argument, store the computed in a const.
    // Computed variables are refs, so we can access to computedUserName.value
    // but only are read variables, we cann't modify computedUserName.value='NewName';
    const computedUserName = computed (
      function(){
        return firstName.value + ' ' + secondName.value; // remember: only allow to omit .value in templates
      }
    );
    
    // exposes ref variables for v-model and computed property
    return {       
        firstName, secondName, computedUserName
    }; 
  }
};
```

```html
<section class="container">    
    <h2>{{ computedUserName }}</h2>    
    <div>
      <input type="text" placeholder="First Name" v-model="firstName">
      <input type="text" placeholder="Last Name" v-model="secondName"> 
    </div>
  </section>
```

### 10.06 Watchers

The wathers can also applied to ref and reactive, let's use here an example with ref:

```javascript
import { ref, watch } from 'vue'; // this is mandatory

export default {
  setup(){         
    const usName = ref('Belizón');
    
    // Modifying ref
    setTimeout(() => {
      usName.value = 'New Name';
    }, 3000);

    // the first argument of watch function it's the dependency of the watch, 
    // when has Vue to execute the watcher function. The second argument it's the function we want to execute.
    watch(usName,  // whenever usName changes, this function it's executed
      function(newValue, oldValue){ // this function receives automatically this 2 arguments
        console.log('newValue usName: ' + newValue);  // Don't need .value
        console.log('oldValue usName: ' + oldValue); 
    });    
    
    return {       
        // don't need expose to use watchers, due they executed when some value changes
    }; 
  }
};
```

We can have multiple dependencies using an array in the first argument of the watch function. The function will be executed when any of the dependencies chenges:

```javascript
// Inside setup 
watch([usAge, usName],
  function(newValues, oldValues){ // both arguments are arrays in this case
      console.log('newValue usAge: ' + newValues[0]);  // The order in the arrays it's equals as the orders in dependiencies
      console.log('oldValue usAge: ' + oldValues[0]);
      console.log('newValue usName: ' + newValues[1]);
      console.log('oldValue usName: ' + oldValues[1]);
  }
);
```

As in Vue2, you can`t watch the contains of an array or an object:

```javascript
// Inside setup 
const user = reactive({ name: 'Belizón', age: 17 });

watch(() => user.name, // First argument it's a getter
    function(newValue, oldValue){
        console.log('oldValue: ' + oldValue);
        console.log('newValue: ' + newValue);
    });
```
