# 03-advanced-components

In this project we will see advance concepts of components.

### 03.01 Slots
VueJs reserves 'slots' to pass components complex content from outside. In the component we want to receive content we can use the reserved tag from Vue: <slot></slot>

```html
<!-- 
quote component: as you can see, it has a specific zone for content from the parent 
-->
<template>
  <div>
    <slot></slot> <!-- This is a reserve space to inject what the component will receive. -->
  </div>    
</template>
```

Automatically, we can write content inside the tag of our component wen using it like this:
```html
<!-- 
When we use quote components we can write code inside the tag 
that will be passed to the component and rendered in the slot. 
-->
<quote>
    <h4>{{ quoteTitle }}</h4>
    <p>No son molinos, son gigantes.</p>
</quote>
```
The content inside the tag component will be rendered in the child.

###### Compilation
The styles that applies to the injected content will be the defined:
 - If it's defined in the parent, applies that style ignoring the styles in child.
 - If it isn't defined in the parent, applied the style in child.

Every Vue processing will be executed before passing the content to the component. For example v-if, v-for directives, {{ }} operators...

###### Splitting slots

We can  divide the content inside the child assigning names to de <slot> tag:
```html
<template>
  <div>
    <slot name="miRefName"></slot>
  </div>    
</template>
```
In the parent we can assign that names to our injected content:
```html
<quote>
    <h2 slot="miRefName">blablabla</h2>
</quote>
```

###### Default slots
In the child component we can put content inside the <slot> tag and it will be rendered if the parent don't pass content for that particular slot.
```html
<template>
  <div>
    <slot name="subTitle">This it's written in the child. It will be shown as default if the parent don't specify subTitle slot</slot>
  </div>    
</template>
```

### 03.02 Dynamic Component

```<component>``` tag allows add to dynamic add component
The ```is``` attribute has to content an string that it's equal to component selector. 

```
<component :is="selectedComponent">        
</component>
```

###### Lifecycle of dymanic components

How the is components behaviour?

When a component is loaded using ```<component>``` tag, that component is created each time. In this example we have a counter in 'New' component with a counter starting at 0 and a button that increase that counter. If we load other component clicking in Author button and then click again to New button to load the New component, the counter start at 0 again.

When a component is unload from ```<component>``` tag, it calls the destroy event of the lifecycle of Vue. 
When a component is load in ```<component>``` tag, it calls the created event of the lifecycle of Vue.

```javascript
  created(){
    console.log('Call created for New component');
  },
  destroyed(){
    console.log('Call destroyed for New component');
  }
```

To overwrite that default behaviour we can wrap the ```<component>``` tag under a ```<keep-alive>``` tag. So either created and destroyed doesn't call. Well, obviously the created event is called the first time a component is loaded

```html
<keep-alive>
  <component :is="selectedComponent"></component>
</keep-alive>
```

When using ```<keep-alive>``` tag, instead using created and destroyed hooks, we can use activated and deactivated:

```html
activated(){
  console.log('Call activated in New component');
},
deactivated(){
  console.log('Call deactivated in New component');
}
```
