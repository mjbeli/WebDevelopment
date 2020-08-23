<template>
  <div class="about">
    <h2>Components basics for Vue</h2>
    <!-- 
      We can use mi-componente here without importing it (like we have done with others)
      because we already have registered it globally in main.js
    -->
    <mi-componente v-for="server in 5"> </mi-componente> <!-- Repeat 5 times this element-->

    <hr>
    <RickMortyPhotoComp />
  </div>
</template>

<script>
// @ is an alias to /src
import RickMortyViewerComponent from '@/00 Components/RickMortyViewerComponent.vue'


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

