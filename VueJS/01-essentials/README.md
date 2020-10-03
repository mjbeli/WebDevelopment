# 01-essentials

### 01.01 Interpolation

Given a section of html controlled by Vue, we can print any data declared into the ```data``` section. This section always must be a function that return an object. Inside the object we can declare anything (number, string, array, object) anda that will ve accesible from the html section controlled by Vue.

```html
<!-- This section is under control of Vue, so Vue will recognize the {{ }} operator and will process what it's inside -->
<div>
    {{message}}
</div>
```

```javascript
<script>
// script section of a template in Vue.
export default {
  data(){
    return {
      message: 'hello world!'
    }
  }  
}
</script>
```

Inside the double curly braces we can call simple javascript expressions like ```{{ 1+1 }}``` or ```{{ Math.random() }}``` but we can't write an if-else for example.

*Important!* The double curly braces syntax it's only available between opening and closing html tags.

### 01.02 v-bind

If we want to assign dynamic value to an attribute of an html tag, we must use ```v-bind```. This is a Vue directive, that means it's a reserved word detected and processes by Vue.

This directive has a shortcut ==> just put ```:``` as prefix of the attribute and Vue will use v-bind.
```html
<!-- With v-bind we can access inside properties declared inside the objects that returns the data function -->
<p>Learn more <a v-bind:href="vueLink">about Vue</a>.</p>
<p>Learn more <a :href="vueLink">about Vue</a>.</p>
```
```Javascript
<script>
export default {
  data(){
    return {
      vueLink: 'https://vuejs.org/'
    }
  }  
}
</script>
```

Inside the v-bind we can call simple javascript expressions like ```{{ 1+1 }}``` or ```{{ Math.random() }}``` but we can't write an if-else for example.

### 01.03 methods

The methods options allow us define functions that we can use as explicit calls or in envents like clicks. Methods option it's an object that will be full of functions.

All the functions defined inside methods option can be called from our html code (remember, the section of html code controlled by Vue).

```Javascript
<script>
export default {
  data(){
    return { /* ... */ }
  },
  methods: { // 'methods' is a reserved word. All defined inside must be a function!
    outputGoal(){
      return (Math.random() < 0.5 ? 'Learn Vue' : 'Master Vue');
    }
  }  
}
</script>
```

```html
<!-- Calling a function defined in methods option. Remember we are just calling a function, so we'll need the () -->
{{ outputGoal() }} 
```

#### 01.03.01 How methods works

Watch out using a method !!! 

Vue can't anticipate what a method do, so when any changes occur in the page, Vue will re-execute all the methods inside a `{{ }}` operator or inside a `v-bind` directive.

That means, for example, that if we update a data property clicking a button, Vue will re-execute all methods because it don't know if the data property will affect the execution of the method. Note that Vue it's extremelly reactive, and execute the methods for in case the modification changes these methods.

For solving this, use a computed property (see bellow).

In the next example, every time the user click the button, the counter property will change so *every* method in curly braces or in v-bind will be re-execute:

```javascript
<script>
export default {
  data(){
    return { counter: 0 }
  },
  methods: { 
    outputGoal(){
      return (Math.random() < 0.5 ? 'Learn Vue' : 'Master Vue');
    }
  }  
}
</script>
```

```html
<div>
  <button @click="counter++">Add</button> 
  {{ counter }} 
  {{ outputGoal() }} <!-- This method will be re-executed every time the user click the button!!! -->
</div>
```

#### 01.03.02 Accessing data from methods

From the ```methods``` option we can use the properties defined in ```data()``` option using the ```this.``` modificator. Vue takes all the data returned in the object of data option and merge its into a global object managed by Vue instance.

```Javascript
<script>
export default {
  data(){
    return { msg1: 'Learn Vue', msg2: 'Master Vue' }
  },
  methods: { // 'methods' is a reserved word. All defined inside must be a function!
    outputGoal(){
      return (Math.random() < 0.5 ? this.msg1 : this.msg2);      
    }
  }  
}
</script>
```

### 01.04 v-html

By default, the processed value inside ```{{ }}``` operator won't interpreted raw html code. In case we want the html tags be interpreted, we can use v-html directive:

```html
<!-- Can also call a function difined inside methods option like: <p v-html="printmessage(message)"> -->
<p v-html="message">
</p>
```

```javascript
<script>
// script section of a template in Vue.
export default {
  data(){
    return {
      message: '<h3>hello world!</h3>'
    }
  }  
}
</script>
```

### 01.05 v-on

The same way we can bind data with v-bind directive, we can attach a function to an event using the `v-on` directive. The event to witch we want to attach will be specified after de colon `:`. Inside the event we can write simple Javascript expressions, including call a function defined in methods option.

The events we can subscribe are any events of html elements like: click, mouseenter, mouseleave, keyup, keydown, ...
This directive has a shortcut `@click=""`

```javascript
<script>
export default {
  data(){
    return { counter: 0 }
  },
  methods: {
    add(){
      this.counter++; // this. it's mandatory to access object returned by data() option
    }
  }
}
</script>
```

```html
<div>
  <button v-on:click="add">Add</button> <!-- Vue detects add it's a function even without the () -->
  <button @click="counter--">Reduce</button>
  {{ counter }} <!-- This counter will update automatically. This is the magic of Vue reactivity! -->
</div>
```

### 01.06 v-once

If we have some data that changes but, for any reason we need to show the initial state ignoring the changes, we can use the `v-once` directive.

All the expresion inside the html tag with `v-once` will be evaluated only at the begining.

```html
<p v-once>Initial counter value: {{ counter }} </p>
```

### 01.07 event modifiers

List of event modifiers: https://v3.vuejs.org/guide/events.html#event-modifiers

`.prevent` modifier prevent the default browser behaviour, for forms that means not sending an http request to the server
```html
<form @submit.prevent="submitForm">
</form>
```

`@click.stop` prevent the event propagation.

`@click.right` --> listen to the right button click mouse event instead the left (default).

`@click.middle` --> listen to the middle button click mouse event instead the left (default).

`@keyup.enter` --> fired when pressed enter key.

`@keyup.ctrl` --> fired when pressed control key.

`@keyup.shift` --> fired when pressed shift key.

`@keyup.page-down` --> fired when pressed arrow down key.

### 01.08 v-model

`v-bind` it's a one direction binding. We can set a data property to an enter but we can't reflect the changes in the data property back to the html.

`v-model` is a bidirectional binding. That means that when the data property it's modified in the javascript the input will be modified.

```javascript
export default {
  name: 'App',
  data() {
    return { myNameData:'' }
  },
  methods: {    
    resetName(){ this.myNameData=''; }
  }  
}
</script>
```

```html
<!-- When clicking the button, the input will be cleared due to bidirectional binding -->
<input type="text" v-model="myNameData"> 
<button @click="resetName">Reset</button>
{{myNameData}}
```

*Important!* v-model it's a shortcut for a combination of `:value` and `@input`.