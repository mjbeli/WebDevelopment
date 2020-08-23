<template>
  <div>
   <p>
     Este es el componente RickMortyViewerComponent, desde el cual se llama a una api pública rest que devuelve una imagen de rick y morty aleatoria cada vez que se hace clic en un botón.     
   </p>
   <button @click="GetRemoteCharacter()">Jo, tio</button>
  <div>
    <img :src="imageSource" />
  </div>
  </div>
</template>

<script>
import rickandmortyapi from '../source/RyM_Api';
import RickMortyViewerComponent from '@/00 Components/RickMortyViewerComponent.vue';

export default {
  name: 'RickMortyViewerComponent',
  /*
   In components, data it's a function. 
   https://vuejs.org/v2/guide/components.html#data-Must-Be-a-Function
   
   A component’s data option must be a function, so that each instance of the component can maintain an independent copy of the returned 'data' object.
   If Vue didn’t have this rule, updating one intance of the component would affect the 'data' of all other instances.
  */
  data () {
    return {
      imageSource: String
    }
  },
  methods: {
    GetRemoteCharacter(){
      let rymApi = new rickandmortyapi(); // encapsule the api call in a class
      rymApi.GetRandomRemoteCharacter(30)
              .then(result => {
                    this.response = result.data;
                    this.imageSource = this.response.image;
                }, error => {
                  console.error(error);
                });
      
    }
  },
  mounted(){      
      this.GetRemoteCharacter(); // Again, it's mandatory to use "this. here
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
</style>
