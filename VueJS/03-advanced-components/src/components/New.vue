<template>
  <div>
    <h5>
       New
    </h5>
    <button @click="counter++">Increase counter</button>
    <p>{{ counter }}</p>
  </div>    
</template>

<script>
export default {
  name: 'NewComponent',
  data: function(){
    return {
        counter: 0
    }
  },
  created(){
    console.log('Call created for New component');
  },
  destroyed(){
    console.log('Call destroyed for New component');
  },
  activated(){
    console.log('Call activated in New component');
  },
  deactivated(){
    console.log('Call deactivated in New component');
  }
}
</script>


<style scoped>
</style>
