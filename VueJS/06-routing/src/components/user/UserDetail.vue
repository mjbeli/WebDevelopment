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
</div>
</template>
<script>
export default {
    props: ['id']
}
</script>