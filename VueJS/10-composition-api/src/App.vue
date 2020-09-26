<template>
  <section class="container">
    <!-- In the template we don't need to acces to .value, Vue will access the .value automatically -->
    <h2>{{ userName }}</h2>
  </section>
  <section class="container">    
    <h2>{{ user.name }}</h2>
    <h2>{{ user.age }}</h2>
  </section>
</template>

<script>
import { reactive, ref } from 'vue';

export default {
  setup(){ // here goes data, methods, computed and watchers

    // 'ref()' creates a reactive variable, and stored it into a constant.
    // We can pass the initial value as an argument.
    const usName = ref('Belizón'); 

    // if here we do somethig like usName = 'New name'; won't work because we are
    // destroying the reactive object! We need to work with usName.value so the reactive reamins
    // That's the reason because we declare a constant.
    setTimeout(() => {
      usName.value = 'New Name';
    }, 3000);


    // 'reactive()' makes an object reactive. Don't need to access value to change the attributes.
    const user = reactive({ name: 'Belizón', age: 17 });
    setTimeout(() => {
        user.name = 'New Name to user object';
        user.age = '18';
    }, 3000);

    // Every things we want to be available in the DOM (in our template section).
    // we need an extra step: return an object with all we want to expose to the template.
    // setup() always return an object:
    return {
        userName: usName, // this exposes to the DOM a variable called 'userName' that it's usName inside setup() function.
        user // exposes the object as reactive
    };
  }

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