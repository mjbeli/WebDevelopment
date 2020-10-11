<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App"/>
</template>

<script>

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
          },
          {
          id: 'bb',
          name: 'bb',
          telephone: '67890',
          email: 'bb@invent.com'
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
