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
export default {
  name: 'RickMortyViewer',
  data () {
    return {
      imageSource: String,
      urlGetOneCharacter: 'https://rickandmortyapi.com/api/character/'
    }
  },
  methods: {
    GetRemoteCharacter(){
      let character = generateRandom();
      let urlCharacter = this.urlGetOneCharacter + character;

      this.$http.get(urlCharacter)
            .then(result => {
                    this.response = result.data;
                    this.imageSource = this.response.image;
                }, error => {
                  console.error(error);
                });
      }
  },
  created(){
    this.GetRemoteCharacter(); // Again, it's mandatory to use "this. here
  }
}

function generateRandom()
{
  return Math.ceil(Math.random() * 10);
};

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
a {
  color: #42b983;
}
</style>
