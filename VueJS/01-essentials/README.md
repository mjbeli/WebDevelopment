# 01-essentials

#### 01.01 Interpolation

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
  name: 'App',
  data(){
    return {
      message: 'hello world!'
    }
  }
  
}
</script>
```

*Important!* The double curly braces syntax it's only available between opening and closing html tags.

#### 01.02 v-bind

If we want to assign dynamic value to an attribute of an html tag, we must use ```v-bind```. This is a Vue directive, that's mean it's a reserved word detected and processes by Vue.

This directive has an shortcut ==> just put ```:``` as prefix of the attribute and Vue will use v-bind.
```html
<!-- With v-bind we can access inside properties declared inside the objects that returns the data function -->
<p>Learn more <a v-bind:href="vueLink">about Vue</a>.</p>
<p>Learn more <a :href="vueLink">about Vue</a>.</p>
```
```Javascript
<script>
export default {
  name: 'App',
  data(){
    return {
      vueLink: 'https://vuejs.org/'
    }
  }
  
}
</script>
```
