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
    <p v-once>Initial counter value: {{ counter }} </p>
    <br>
    <hr>
    <input type="text" v-model="myNameData">
    <button @click="resetName">Reset</button>
    {{myNameData}}
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
      counter: 3,
      myNameData:''
    }
  },
  methods: {
    outputGoal(){
      return (Math.random() < 0.5 ? this.msg1 : this.msg2);
    },
    add(num) {
      this.counter+=num;
    },
    resetName(){
      this.myNameData='';
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
