<template>
  <div>
    <slot></slot>
  </div>    
</template>

<script>
export default {
  name: 'QuoteComponent'
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

div{
  border: 1px solid #ccc;
  box-shadow: 1px 1px 2px black;
  padding: 30px;
  margin: 30px auto;
  text-align: center;
  width: 75%;
}

/* 
Styles only applies if the the parent don't overwrite it. 
In this case it won't be applied because it's already defined in parent.
 */
h4 {
  color: blue;
}

/* 
This style will be apply because it isn`t defined in the parent.
*/
p {
  color: #42b983;
}
</style>
