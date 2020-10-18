<template>
  <!-- In Vue 3 you can have more than one root element-->
  <h3>My agenda</h3>  
  <div>
    <friend-contact v-for="friend in friends" 
                    :key="friend.id" 
                    :id="friend.id" 
                    :name="friend.name" 
                    :phone="friend.telephone" 
                    :email="friend.email" 
                    :isFavourite="friend.isFavourite" 
                    @evt-toggle-favourite="changeFavourite" > </friend-contact>    
  </div>  
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      friends: [
        {
          id: 'aa',
          name: 'aaa',
          telephone: '12345',
          email: 'aa@invent.com', 
          isFavourite: false
        },
        {
          id: 'bbb',
          name: 'bbb',
          telephone: '67890',
          email: 'bb@invent.com', 
          isFavourite: true
        }
      ]
    }
  },
  methods: {
    changeFavourite(friendId){
      console.log('change the favourite mark! ' + friendId);
      let myFriend = this.friends.find(friend => friend.id === friendId);
      myFriend.isFavourite = !myFriend.isFavourite;
    }
  },
  provide: {
    friendToProvide: {
      id: 'cc',
      name: 'ccc',
      telephone: '52850'
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
