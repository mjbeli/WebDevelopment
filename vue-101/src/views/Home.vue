<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">    
    <Store></Store>
  </div>
</template>

<script>
import HelloWorld from '../components/HelloWorld.vue'
import Store from '../components/Store.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld,
    Store
  }
}
</script>
