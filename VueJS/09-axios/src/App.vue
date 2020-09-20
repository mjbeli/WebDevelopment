<template>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
                <h1>Axios</h1>
                <hr>
                <axios-component/>
            </div>
        </div>
    </div>
</template>

<script>
    import AxiosComponent from "./components/AxiosComponent.vue";

    export default {
        data() {
            return {

            }
        },
        components: { AxiosComponent }
    }
</script>

<style>

</style>
