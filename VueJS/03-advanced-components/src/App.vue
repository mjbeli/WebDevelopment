<template>
  <div class="app">
    <img alt="Vue logo" src="./assets/logo.png" class ="smallLogo" >
    <quote>
      <h4 slot="title">{{ quoteTitle }}</h4>
      <p slot="phrase">{{ quote }}</p>
      <p>From the parent, this paragraph don't has a slot assigned so it will be rendered in the default slot.</p>
      <p slot="secondSubTitle">This is written in the parent using slot named as secondSubTitle. The content has been overwriten.</p> 
    </quote>
    <hr>
    <hr>
    <hr>
    <div>
      <button @click="selectedComponent='Author'">Autor</button>
      <button @click="selectedComponent='New'">New</button>
      <button @click="selectedComponent='Quote'">Quote</button>
      <p>Componente seleccionado: {{selectedComponent}}</p>

      <keep-alive>
        <component :is="selectedComponent">
          <p>Default slot</p>
        </component>
      </keep-alive>
    </div>
  </div>
</template>

<script>
import QuoteComp from './components/Quote.vue'
import Author from './components/Author.vue'
import New from './components/New.vue'


export default {
  name: 'App',
  components: {
    Quote: QuoteComp,
    Author,
    New
  },
  data: function (){
    return {
      quoteTitle: 'Mi cita',
      quote: 'No son molinos, son gigantes.',
      selectedComponent: 'Quote' // This name must be igual than name imported in components section.
    }
  }
}
</script>

<style scoped>
/* This style will be applied to the injected content */
h4 {
  color: red;
}

.app {  
  text-align: center;
}

.smallLogo {
  height: 100px;
}


</style>
