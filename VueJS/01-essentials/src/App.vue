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

    <!-- In case fullName it's a computed property, but use it like a property data, 
        don't call it like a function (even when it's actually a function).
        Vue will execute the computed function when its dependencies (reactive data) change. -->
    <p>{{ fullName }}</p> 


    <br>
    <hr>    
    <button @click="addCounterToArray">Add counter to array</button>
    <br>
    ArrayVar: {{arrayVar}}
    <br>
    complexObject.lastCounter: {{complexObject.lastCounter}}
    <br>
    myArrayVarComputedProperty: {{myArrayVarComputedProperty}}
    <br>
    myComplexObjectComputedProp: {{myComplexObjectComputedProp}}

    <!-- v-if -->
    <br>
    <hr>    
    <p v-if="goals.length==0">No goals added </p>
    <ul v-else>
      <li v-for="(goal, index) in goals" :key="goal" @click="removeGoal(index)">{{ index + 1 }} - {{ goal }}</li>
    </ul>
    <input type="text" v-model="enteredGoal"/>
    <button @click="addGoal">Add goal</button>
    <br>
    <!-- 
    Iterates throught each property.
    The first property its the value, the second its the key and the third its the index.
    -->
    <ul>
      <li v-for="(value) in {name:'John Doe', age: 77}" :key="value">{{ value }}</li>     
    </ul>
    <ul>
      <li v-for="(value, key) in {name:'John Doe', age: 77}" :key="value">{{ key }}: {{ value }}</li>     
    </ul>
    <ul>
      <li v-for="(value, key, index) in {name:'John Doe', age: 77}" :key="value">{{ key }}: {{ value }} - {{ index }}</li> 
    </ul>

    <!-- Iterates throught a range of numbers -->
    <ul>
      <li v-for="num in 10" :key="num">{{ num }}</li> 
    </ul>
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
      nameData: '',
      arrayVar: [],
      complexObject: { lastCounter: 3 },
      enteredGoal: '',
      goals: []
    }
  },
  computed: {  
    fullName(){
      if(this.myNameData === '')
        return '';
      return this.myNameData + ' ApellidoData';
    },
    myArrayVarComputedProperty(){
      console.log('Dentro de computed arrayVar');      
      return 'Este es el valor del array '  + this.arrayVar;
    },
    myComplexObjectComputedProp(){
      console.log('Dentro de computed ComplexObject');      
      return 'Este es el valor del atrib '  + this.complexObject.lastCounter;
    }
  },
  watch: {
    // Same name as property data, this function will be executed whenever nameData changes.
    nameData(newValue){ // Second parameter optional: oldValue
      this.myNameData= newValue + ' ApellidoData';
    },
    arrayVar: {
      deep: true,
      handler(value){
        console.log('Dentro de watcher arrayVar');
        console.log('value ', value);
      }
    },
    complexObject:{
      deep: true,
      handler(value){
        console.log('Dentro de watcher complexObject');
        console.log('value ', value);
      }
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
    },
    addCounterToArray(){
      this.arrayVar.push(this.counter);
      this.complexObject.lastCounter = this.counter;
    },
    addGoal(){
      this.goals.push(this.enteredGoal);
    },
    removeGoal(idx)
    {
      this.goals.splice(idx,1);
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
