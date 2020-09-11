<template>
<div>
    <h1>The User Page</h1>
    <hr>
    <p>
        This is the receive ID: {{ id }}
    </p>
    <!-- we could have done this using router-link, but the purpouse ist's to navigate from code-->
    <button @click="navigateToHome" class="btn btn-secondary">Home</button> 
    <hr>
    <!--<keep-alive> When using keep alive, the components loaded in that router-view aren't created or destroyed anymore and share the data-->
        <router-view></router-view> <!-- here loads the sub-routes of this component -->
    <!--</keep-alive>-->

</div>

</template>
<script>
export default {
    props: ['id'],
    methods: {
        navigateToHome(){
            // Inside the Vue instance (this) the objects starting with $ usually tell us it's an
            // object provided by anothe package, in this case vue-router.
            // This push add the route to the stack navigation so it's preserve the behaviour of the
            // back and forward buttons.
            // this.$router.push('/'); 
            this.$router.push({ name: 'Home' }); 
        }
    }
}
</script>