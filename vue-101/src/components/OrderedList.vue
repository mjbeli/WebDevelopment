<template>
  <div class="hello">
    <ol>
      <li class="greenColor" v-for="item in itemList" v-bind:key="item.id">{{item.text}}</li>
    </ol>
  </div>
</template>

<script>
export default {
  name: 'OrderedList',
  props: {itemList: Array}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.greenColor {
  color: #42b983;
  
}
</style>
