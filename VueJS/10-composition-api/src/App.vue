<template>
  <section class="container">
    <!-- In the template we don't need to acces to .value, Vue will access the .value automatically -->
    <h2>{{ userName }}</h2>
  </section>
  <section class="container">    
    <h2>{{ user.name }}</h2>
    <h2>{{ user.age }}</h2>
  </section>

  <section class="container">    
    <h2>{{ computedUserName }}</h2>    
    <div>
      <input type="text" placeholder="First Name" v-model="firstName"> <!--remember don't use .value in templates-->
      <input type="text" placeholder="Last Name" v-model="secondName"> 
    </div>
  </section>

  <section class="container"> 
    <p>Data passed to another component as props</p>   
    <user-data :user-name="userName"></user-data>
  </section>
</template>

<script>
import UserData from './components/UserData';

import { reactive, ref, computed, watch, provide } from 'vue';

export default {
  setup(){ // here goes data, methods, computed and watchers

    // 'ref()' creates a reactive variable, and stored it into a constant.
    // We can pass the initial value as an argument.
    const usName = ref('Belizón'); 
    const usAge = ref(21);
    
    // 'reactive()' makes an object reactive. Don't need to access value to change the attributes.
    const user = reactive({ name: 'Belizón', age: 17 });

    // 2 arguments: first one it's a key of our choice, the second it's de value we want to send to the child
    provide('userAge', usAge);


    const firstName = ref('');
    const secondName = ref('');

    // if here we do somethig like usName = 'New name'; won't work because we are
    // destroying the reactive object! We need to work with usName.value so the reactive reamins
    // That's the reason because we declare a constant.
    setTimeout(() => {
      usName.value = 'New Name';
    }, 3000);

    // Modifying reactive complex object (without .value)
    setTimeout(() => {
        user.name = 'New Name to user object';
        user.age = '18';
    }, 3000);

    setTimeout(() => {
        usAge.value = 23; // modifying injected ref from parent
    }, 3000);
    
    // Defining a function that will be exposed like a method in options API
    function setNewAge(){
      user.age= 22;
    }    

    // Call computed function that receives a function as an argument
    // Computed variables are refs, so we can access to computedUserName.value
    // but only are read variables, we cann't modify computedUserName.value='NewName';
    const computedUserName = computed (
      function(){
        return firstName.value + ' ' + secondName.value; // remember: only allow to omit .value in templates
      }
    );

    // the first argument of watch function it's the dependency of the watch, 
    // when has Vue to execute the watcher function. The second argument it's the function we want to execute.
    watch(usName,  // whenever usName changes, this function it's executed
      function(newValue, oldValue){ // this function receives automatically this 2 arguments
        console.log('newValue usName: ' + newValue);  // Don't need .value
        console.log('oldValue usName: ' + oldValue); 
    });

    watch(() => user.name,
    function(newValue, oldValue){
        console.log('oldValue: ' + oldValue);
        console.log('newValue: ' + newValue);
    });
    

    // Every things we want to be available in the DOM (in our template section).
    // we need an extra step: return an object with all we want to expose to the template.
    // setup() always return an object:
    return {
        userName: usName, // this exposes to the DOM a variable called 'userName' that it's usName inside setup() function.
        user, // exposes the object as reactive, if we exposes the attributes the Dom won't be updated.
        setAge: setNewAge, // exposes the function the same way we exposes the data, this is a pointer to the function.
        firstName, secondName,
        computedUserName
    };
  },
  components: { UserData }

};
</script>

<style scoped>
* {
  box-sizing: border-box;
}

html {
  font-family: sans-serif;
}

body {
  margin: 0;
}

.container {
  margin: 3rem auto;
  max-width: 30rem;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
  padding: 1rem;
  text-align: center;
}
</style>