<template>
  <div>
    <h2>Comunication between components</h2>
    <div class="row">
      <servers></servers>    
      <app-server-details></app-server-details>        
    </div>
    <div class="row">           
      
    </div>
  </div>
</template>

<script>

import servers from '../01 ComunicatingComponents/Servers.vue';
import ServerDetails from '../01 ComunicatingComponents/ServerDetails.vue';

export default {
  name: 'ComponentPage',
  components: {    
    servers,
    'app-server-details': ServerDetails
  }
}
</script>

<style scoped>

</style>


