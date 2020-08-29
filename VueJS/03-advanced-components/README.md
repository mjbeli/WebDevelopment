# 03-advanced-components

In this project we will see advance concepts of components.

#### Slots
VueJs reserves 'slots' to pass components complex content from outside. In the component we want to receive content we can use the reserved tag from Vue: <slot></slot>

```html
<template>
  <div>
    <slot></slot> <!-- This is a reserve space to inject what the component will receive. -->
  </div>    
</template>
```

Automatically, we can write content inside the tag of our component wen using it like this:
```html
<quote>
    <h4>Mi cita</h4>
    <p>No son molinos, son gigantes.</p>
</quote>
```
The content inside the tag component will be rendered in the child.

###### Compiles
The styles that applies to the injected content will be the defined:
 - If it's defined in the parent, applies that style ignoring the styles in child.
 - If it isn't defined in the parent, applied the style in child.

Every Vue processing will be executed before passing the content to the component. For example v-if, v-for directives, {{ }} operators...

###### Splitting slots

We can 


## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Lints and fixes files
```
npm run lint
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).