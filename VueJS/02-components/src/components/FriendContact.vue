<template>
  <!-- This html code will be injected in all sites where we use the component -->
  <div>
      <h4> {{ name }} {{ isFavourite ? '(Favourite)' : '' }} </h4>
      <button @click="toggleDetails">  {{  buttonText  }} </button>
      <button @click="toggleFavourite"> Toggle Favourite </button>
      <div v-if="detailsVisible">
          <span><strong>Phone:</strong> {{ phone }}</span>
          <span><strong>Email:</strong> {{ email }}</span>
      </div>
  </div>  
</template>
<script>

export default {
    name: 'friend-contact',
    props: ['id', 'name', 'phone', 'email', 'isFavourite'],
    emits: {
        // The key it's the name of the event and the value it's a function that receives as parameter the data emitting
        'evt-toggle-favourite': function(id){ // Here we're saying that this event should be handled by a function that receives an id.
            if(id) // this is a validation
                return true;
            else{
                console.warn('Id is missing');
                return false;
            }
        }
    },
    data(){
        return {
            detailsVisible: false       
        }
    },
    methods: {
        toggleDetails(){
            this.detailsVisible = !this.detailsVisible;
        },
        toggleFavourite(){
            this.$emit('evt-toggle-favourite', this.id);
        }
    },
    computed: {
        buttonText(){            
            if(this.detailsVisible)
                return 'Hide Details';
            return 'Show Details';
        }
    }    
}
</script>
<style scoped>

</style>