<template>
  <div class="hello">
   <h6>Cada vez que le des al siguiente botón, deberías ver un personaje diferente de Rick y Morty.</h6>
   <button @click="GetRemoteCharacter()">Jo, tio</button>
  <div>
    <img :src="imageSource" />
  </div>
  </div>
</template>

<script>
import rickandmortyapi from '../source/RyM_Api';

export default {
  name: 'RickMortyViewer',
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
