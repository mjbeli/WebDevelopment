<template>
  <div>
    {{ message }}

    <p>Learn more <a v-bind:href="vueLink">about Vue</a>.</p>
    <p>Learn more <a :href="vueLink">about Vue</a>.</p>

    <br>
    <hr>
    <!-- Calling a function defined in methods option. We are calling a function, so we'll need the () -->
    {{ outputGoal() }} 

    <br>
    <hr>
    <button v-on:click="add(2)">Add</button>
    <button @click="counter--">Reduce</button>
    {{ counter }} 

    <br>
    <hr>
    <form>
      <input type="text"> 
      <button>sign up</button>
    </form>

  </div>
</template>

<script>
export default {
  name: 'App',
  data(){
    return {
      message: 'hello world!',
      vueLink: 'https://vuejs.org/',
      msg1: 'Learn Vue', msg2: 'Master Vue',
      counter: 0
    }
  },
  methods: {
    outputGoal(){
      const randomNumber = Math.random();
      if(randomNumber < 0.5)
        return this.msg1;
      else
        return this.msg2;
    },
    add(num) {
      this.counter+=num;
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
