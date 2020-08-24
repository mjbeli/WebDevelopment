<template>
  <div class="custom-css">
    <h2>Components basics for Vue</h2>
    <!-- 
      We can use mi-componente here without importing it (like we have done with others)
      because we already have registered it globally in main.js
    -->
    <mi-componente v-for="server in 5"> </mi-componente> <!-- Repeat 5 times this element-->

    <hr>

    <!-- Thanks to webpack & ES6 we can use the component with '-' annotation and case insensitive -->
    <rickmorty-photo-comp />
  </div>
</template>

<script>
import RickMortyViewerComponent from '../00 Components/RickMortyViewerComponent.vue'


export default {
  name: 'ComponentPage',
  components: {    
    // This is a way to define the selector for my component
    RickMortyPhotoComp: RickMortyViewerComponent 
    // Alternative I can define the component this way to use the same selector than the import name
    // RickMortyViewerComponent // ES6 will transfrom this to RickMortyViewerComponent
  }
}
</script>

<!-- 
Scoped indicates that the css defined only applies to this component.
If scoped it's omited, then the css it's globally for all the application.
How do this VueJs?
Automatically, Vue generates the elements inside a componen with an unique attribute like this:<style scoped>
    <div data-v-3818c4ff="" class="custom-css">
      <h2 data-v-3818c4ff=""> blablabla </h2>
    ...
    ...
    </div

Note that the elements inside a component have the same attribute.

Inside the head tag for each component Vue generate an <style> tag like this:
    <style type="text/css">
    .custom-css[data-v-3818c4ff]{
      border: 2px solid blue;
    }
    </style>

That's means the style border only applis to classes calleds custom-css with attribute "data-v-3818c4ff".

This is the way Vue simulates having several sub DOMs instead one global DOM.
-->
<style scoped>
.custom-css{
  border: 2px solid blue;
}
</style>


