<template>
    <div>
        <br>
        <p>Message status: {{ status }}</p>
        <button @click="changeStatus" >Change status</button>
    </div>
</template>

<script>

export default {
    data: function(){
        return {
            status: 'mensaje de bienvenida'
        }
    },
    methods:{
        changeStatus(){
            this.status = 'le has dado al boton';
        }
    }
}
</script>

<style>

</style>