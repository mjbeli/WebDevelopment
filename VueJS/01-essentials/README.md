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

This directive has a shorthand ==> just put ```:``` as prefix of the attribute and Vue will use v-bind.
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
This directive has a shorthand `@click=""`

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
<script>
export default {
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

*Important!* v-model it's equal as a combination of `:value` and `@input`.

### 01.09 computed properties

Computed properties are essentially like methods but Vue will be aware of its dependencies and Vue will only re-execute the function if any od its dependency changes. 

Computed option is a reserved word in Vue that is declared as an object of functions, just like methods options. The functions declared inside computed option will be used like a data property, not like a method. Even when they are functions.

```javascript
<script>
export default {
  data() {
    return { myNameData:'' }
  },
  computed: {    
    fullName(){
      if(this.myNameData === '')
        return '';
      return this.myNameData + ' ApellidoData';
    }
  }  
}
</script>
```

```html
<!-- fullName it's a computed property, but use it like a property data, 
  don't call it like a function (even when it's actually a function).
  Vue will execute the computed function when its dependencies (reactive data) changes. -->
<p>{{ fullName }}</p> 
```

The different between using a function in methods or a computed property is not in the behaviour (the output will be the same). It's in the performance. The function method will recalcule every time there is a change in the application (like modifying a counter that isn't related with our `fullName`). Instead, computed properties will recalculate only when any of its dependencies changes.

In general, you can use methods for handling events and computed property for output something to the screen. Computed properties are specially useful when we want to calculate some output value dynamically. 

Computed properties works as we can expect with arrays and objects. That means that when we have a dependency with an array or an object in a computed property will be recalculated when the content of any changes.


#### 01.09.01 setters for computed properties

Doc: https://v3.vuejs.org/guide/computed.html#computed-setter

By default, computed properties are getter-only, must return something, but we can provide a setter in this way:

```javascript
computed: {
  fullName: {    
    get() { 
      return this.firstName + ' ' + this.lastName
    },    
    set(newValue) {
      const names = newValue.split(' ');
      this.firstName = names[0];
      this.lastName = names[names.length - 1];
    }
  }
}
```

Now we can use the computed property as a data property but for setting fullname and doing `this.fullname = 'My Name'` will set the firstName as 'My' and the second name as 'Name'.

### 01.10 watchers

A watcher it's basically a function that Vue will execute when one of its dependencies changes. Vue has a reserved word for declaring watchers that its `watch`. That option its an object with a bunch of functions, like methods or computed.

When you declare a watcher, the function must have the same name as a data property or a computed property. That tells Vue to rexecute the watcher whenever the data or computed property changes. Watchers don't return anything because we are not going to use the watcher in the html code.

Automatically the watchers receive 0, 1 or 2 arguments. The first argument its the new value of the property watched and the second argument its the old value.

```javascript
<script>
export default {
  data() {
    return { myNameData:'',  nameData: '' }
  },
  watch: {
    // Same name as property data, this function will be executed whenever nameData changes.
    nameData(newValue){ // Second parameter optional: oldValue
      this.myNameData= newValue + ' ApellidoData';
    }
  }
}
</script>
```

This example could be achieve with a computed property but watchers are useful when we want to run some code in reaction of a property change (send an http request, store something in vuex,...). Typically for non-data update.

#### 01.10.01 watch arrays and objects

You can notice that watchers doesn't work as we espected with arrays and objects. We can watch arrays and objects, but the watcher function won't fire when the content of arrays and objects changes!

Well, each watch function has a `deep` property that can be set to `true`. When using `deep` the functions itself will be defines in the handler:

```javascript
data(){
  return {      
    arrayVar: [], complexObject: { lastCounter: 3 }
  }
},
watch: {
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
}
```

It seems the handler function only receives the newValue as first parameter (not oldValue in second parameter).

#### 01.10.02 execute watcher in load

Watcher only fires when the data changes, but there is a way to execute a watcher in the first load using the inmediate property:

```javascript
watch: {
  arrayVar: {
      immediate: true, // Will fire as soon as the component is created
      handler(value){ // the code of the watcher
      console.log('Dentro de watcher arrayVar');
      console.log('value ', value);
    }
  }   
}
```


### 01.11 v-bind with class attribute

Ok, so we can use `v-bind` or `:` to bind our class attribute to a method or computed property so we can stablish the styling dinamycally. This is a common case and Vue has an special syntax for doing this a little more readable:

```html
<div 
  class="demo"
  :class= "{cssStyleToApply: booleanExpression}" > <!-- Consider creating a computed property that returns this object-->
</div>
```

```html
<!-- This is exact as the previous but with array syntax: 
      demo will always applied and the other depends on an boolean expression -->
<div   
  :class= "['demo', {cssStyleToApply: booleanExpression}]" > 
</div>
```

```vue
<script>
export default {
  data() {
    return { booleanExpression:true }
  }
}
</script>
<style scoped>
.cssStyleToApply{
  border-color: red;
}
</style>
```

Note that we can combine a traditional and hardcoded class attribute with a binding class attribute. Vue atomatically resolve the binding and merge the result with the hardcoded class attribute so at the end we will have the 2 styles.

Now let`s analize the binding class attribute. We are using here an special annotation that Vue give us. It's an json object where the first its the CSS name style we want to apply and the second its a boolean expression. If the boolean expression its true, the css style will apply.

### 01.12 v-if

With this directive, the html tag only is added to the DOM if the condition it's true. As a Vue directive, we can put between the double quotes a simple Javascript expression or make reference to a computed/data property or a method (always the method returns true or false).

All the child elements of the html tag will be added to the DOM, or not, depending on the condition.

We can use the `v-else` directive to alternative add a html tag to the DOM if the condition of the `v-if` is false. Just as a regular else expression in any other language. It's mandatory that the gtml tag that has the `v-else` directive it's located inmediatly after the tag with the `v-if` expression.

```vue
<template>
  <p v-if="goals.length==0">No goals added </p>
  <ul v-else>
    <li>Goal</li>
  </ul>
</template>
<script>
export default {
  data() {
    goals: []
  }
}
</script>
```

We can use the `v-else-if="..."` directive to implement... well.. the else if statment.

### 01.12 v-show

The `v-show` directive indicates if an html tag (and all its childrens) are visible in the final html page. The element with `v-show` is always added to the DOM, but if the condition returns false the style property 'display' is set to 'none'.

This directive doesn't works with v-else or v-else-if, so if we have multiple alternatives we must to use multiples `v-show` directives. 

```vue
<template>
  <p v-show="goals.length == 0">No goals added </p>
  <ul v-show="goals.length > 0">
    <li>Goal</li>
  </ul>
</template>
<script>
export default {
  data() {
    goals: []
  }
}
</script>
```

Adding or removing elements to the DOM using `v-if` can have a cost performance, but in the other hand if we uses lots of `v-show` we'll have elements in the DOM that we really don't need. A possible informal rule to apply one or other is: uses `v-if` by default and uses `v-show` if the element changes its visibility a lot.

### 01.13 v-for

The `v-for` directive allow us to repeat a element 'n' times. As always, inside the double quotes we can put a javascript expression. In the scope of the html tag that holds the `v-for`, thats means between the open and clos of the tag and inside the tag itself, we can access the variables of the iteration.

*Important!* To help Vue manage the items in a list we must define a key. Strange bugs can happend when we are adding and deleting items from a list dinamically, and it happends because Vue don't create and delete the items the way we expect. Vue take the dynamic elements in each item (the variables in curly braces) and replace it into the new position in the list in the DOM, but Vue don't replace the static elements (like charaters in an input element or statid labels). So in order to help Vue with this and that the static elements will be replace we must provide a the `key` attribute. It isn't a html attribute, its a Vue attribute.

We need something that identify each item in a `v-for` (so its a good idea to v-bind the key). In case you are temptet to use the index, remember the index doesn't belong to the content of each item, the first index will have always index 0, even if we change it. Here we aren't using a real unique identifier.

```vue
<template>
  <ul>
    <li v-for="goal in goals" :key="goal">{{ goal }}</li>
  </ul>
  <ul>
    <!-- In each iteration we can have more than just the item, we can have the index. -->
    <li v-for="(goal, index) in goals" :key="goal">{{ index + 1 }} - {{ goal }}</li>
  </ul>
</template>
<script>
export default {
  data() {
    goals: []
  }
}
</script>
```

We can loop throught an object using v-for:
```vue
<template>
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
</template>
```

We can loop throught a range of numbers:

```vue
<template>
  <!-- Iterates throught a range of numbers -->
  <ul>
    <li v-for="num in 10" :key="num">{{ num }}</li> 
  </ul>
</template>
```
