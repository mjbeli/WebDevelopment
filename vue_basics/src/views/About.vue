<template>
  <div class="about">
    <h1>This is an about page</h1>
    
    <hr><hr><hr>
    <VisibleMsg mensajeMostrar = "Ahora me ves2!"/>
    
    <!-- It's mandatory to use v-bind (or ':') to tell Vue that is a variable, not a simple string -->
    <OrderedList :itemList="groceryList" />


    <RickMortyViewer />

    <hr>
    <hr>

    <RickMortyViewer />


  </div>
</template>

<script>
// @ is an alias to /src
import VisibleMsg from '@/components/VisibleMsg.vue'
import OrderedList from '@/components/OrderedList.vue'
import RickMortyViewer from '@/components/RickMortyViewer.vue'

export default {
  name: 'About',
  components: {
    VisibleMsg, 
    OrderedList,
    RickMortyViewer
  },
  data () {
      return {groceryList: [{ id: 0, text: 'Vegetables' },
                            { id: 1, text: 'Cheese' },
                            { id: 2, text: 'meat' }],}
  }
}
</script>

