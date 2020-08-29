<template>
  <div>
    Author
  </div>    
</template>

<script>
export default {
  name: 'AuthorComponent'
  ,  
  created(){
    console.log('Call created for Author component');
  },
  destroyed(){
    console.log('Call destroyed for Author component');
  },
  activated(){
    console.log('Call activated in Author component');
  },
  deactivated(){
    console.log('Call deactivated in Author component');
  }
}
</script>

