<template>
<div>
    <h3>Some User Details</h3>
    <p> Details for user {{ id }}</p>
    <!-- attribute to needs the colon to receive an object -->
    <router-link tag="button" 
                :to="{ 
                    name: 'UserEdit', 
                    params: { id: id }, 
                    query: { locale: 'en', q: 100 },
                    hash: '#data' 
                    }">
                Edit User</router-link>
    
    <p>Valor del contador interno de este componente: {{counter}}</p>
    <button @click="counter++;">Incrementa contador </button>
</div>
</template>
<script>
export default {
    props: ['id'],
    data(){
        return {
            counter: 0
        }
    },
    created(){
        console.log('Evento created de UserDetail');
    },
    destroyed(){
        console.log('Evento destroyed de UserDetail');
    },
    activated(){
        console.log('Evento activated de UserDetail');
    },
    deactivated(){
        console.log('Evento deactivated de UserDetail');
    }
}
</script>