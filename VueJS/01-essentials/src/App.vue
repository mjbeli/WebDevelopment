<template>
  <div>
    {{message}}

    <p>Learn more <a v-bind:href="vueLink">about Vue</a>.</p>
    <p>Learn more <a :href="vueLink">about Vue</a>.</p>
  </div>
</template>

<script>

export default {
  name: 'App',
  data(){
    return {
      message: 'hello world!',
      vueLink: 'https://vuejs.org/'
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
