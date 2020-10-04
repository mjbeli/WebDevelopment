<template>
  <div>
    {{ message }}

    <p>Learn more <a v-bind:href="vueLink">about Vue</a>.</p>
    <p>Learn more <a :href="vueLink">about Vue</a>.</p>

    <br>
    <hr>
    <!-- 
      Calling a function defined in methods option. We are calling a function, so we'll need the () 
      ouputGoal() will be rexecuted every time we click add or reduce buttons because there's a reactive data
      changing its value and Vue doesn´t know if thats interfire with outputGoal() result 
      (so maybe you should consider using a computed property here)
    -->
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

    <!-- fullName it's a computed property, but use it like a property data, 
        don't call it like a function (even when it's actually a function).
        Vue will execute the computed function when its dependencies (reactive data) change. -->
    <p>{{ fullName }}</p> 
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
      myNameData:'',
      nameData: ''
    }
  },
  computed: {
    // fullName(){
    //   if(this.myNameData === '')
    //     return '';
    //   return this.myNameData + ' ApellidoData';
    // }
  },
  watch: {
    // Same name as property data, this function will be executed whenever nameData changes.
    nameData(newValue){ // Second parameter optional: oldValue
      this.myNameData= newValue + ' ApellidoData';
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
      this.myNameData = '';
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
