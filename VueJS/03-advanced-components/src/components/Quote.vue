<template>
  <div>
    <!-- This will inject the content all together in case in the parent don't have slot attibutes defined.
    In case the parent use slot attributes, this will be the default slot will be this -->
    <slot></slot>

    <hr><hr>
    <!-- Splitting the content -->
    <div>
      <slot name="title"></slot>
      <slot name="subTitle">This it's written in the child. It will be shown as default</slot> 
      <slot name="secondSubTitle">This will be shown as default</slot>      
    </div>
    <div>
      <slot name="phrase"></slot>
    </div>

  </div>    
</template>

<script>
export default {
  name: 'QuoteComponent'
}
</script>

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
