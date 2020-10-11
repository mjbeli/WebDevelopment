# 02-components

### 01.01 Introduction

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

As you can see in the App.vue file, we've got 3 sections: template (html code), script (javascript) and styles (css) that encapsulate all the component behaviour, content and styling:

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
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
```
