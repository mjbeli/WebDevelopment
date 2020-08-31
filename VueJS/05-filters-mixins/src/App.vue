<template>
  <div id="app" class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
                <h1>Filters & Mixins</h1>
                <p>{{ text | myCustomUppercase | my-custom-lowarecase }}</p>
                <p>{{ myComputedPropertyInMixin }}</p>
            </div>
        </div>
    </div>
</template>

<script>

import { myMixin } from './myMixin' // --> so now we have a computed property name myComputedPropertyInMixin

export default {
  name: 'App',
  data(){
    return {
      text: 'Hola mundo!'
    }      
  },
  filters:{
    // Can define a filter like this ---> 'to-uppercase'(){}
    // Alternative way to define a filter:
    myCustomUppercase(value){
      return value.toUpperCase();
    }    
  },
  mixins: [myMixin] // this is an array that specifies all mixins we want to merge in this component.
}
</script>

<style>

</style>
