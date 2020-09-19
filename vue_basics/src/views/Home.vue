<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <!--<HelloWorld msg="Welcome to Your New Vue.js App"/>-->
      <Store></Store>

    
    <VisibleMsg mensajeMostrar = "Ahora me ves!"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import Store from '@/components/Store.vue'
import VisibleMsg from '@/components/VisibleMsg.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld,
    Store,
    VisibleMsg
  }
}
</script>
