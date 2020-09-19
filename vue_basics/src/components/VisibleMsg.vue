<template>
  <div class="hello">
    <button @click="cambiaVisible()">Cambia visibilidad</button>
    <p v-show="showMsg">{{mensajeMostrar}}</p>
    <p>Le has dado {{contador}} veces al botoncito</p>
  </div>
</template>

<script>
export default {
  name: 'VisibleMsg',
  data () {
      return {showMsg: true, contador: 0}
  },
  props: {
    mensajeMostrar: String
  },
  methods: {
    cambiaVisible()
    {
        this.showMsg = !this.showMsg; // This line could be directly inside @click attribute of html tag.
        this.contador++; // Aquí es obligatorio poner el this para hacer referencia a los datos definidos en data() {}
    }
  },
  created(){
    console.log('dentro de created');
  },
  destroyed(){
    console.log('dentro de destroyed');
  },
  activated(){
    console.log('dentro de activated');
  },
  deactivated(){
    console.log('dentro de deactivated');
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.color {
  color: #42b983;
}
</style>
