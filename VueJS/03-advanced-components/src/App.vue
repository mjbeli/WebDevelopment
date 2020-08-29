<template>
  <div class="app">
    <img alt="Vue logo" src="./assets/logo.png" class ="smallLogo" >
    <quote>
      <h4 slot="title">{{ quoteTitle }}</h4>
      <p slot="phrase">{{ quote }}</p>
      <p>This paragraph don't has an slot assigned so it will be renderen in the deafult slot.</p>
      
    </quote>
  </div>
</template>

<script>
import QuoteComp from './components/Quote.vue'

export default {
  name: 'App',
  components: {
    Quote: QuoteComp
  },
  data: function (){
    return {
      quoteTitle: 'Mi cita',
      quote: 'No son molinos, son gigantes.'
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
