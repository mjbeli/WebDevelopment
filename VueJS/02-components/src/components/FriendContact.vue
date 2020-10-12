<template>
  <div>
      <h4> {{ friend.name }} </h4>
      <button @click="toogleDetails"> {‌{ buttonText }} </button>
      <ul v-if="detailsVisible">
          <li><strong>Phone:</strong> {{ friend.phone }}</li>
          <li><strong>Emial:</strong> {{ friend.email }}</li>
      </ul>
  </div>  
</template>
<script>

export default {
    name: 'friend-contact',
    data(){
        return {
            detailsVisible: false,
            friend: {
                id: 'aa',
                name: 'aa',
                phone: '12345',
                email: 'aa@invent.com'
            }
        }
    },
    methods: {
        toggleDetails(){
            this.detailsVisible = !this.detailsVisible;
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