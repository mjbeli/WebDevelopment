<template>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
                <h1>Animations</h1>
                <button class="btn btn-primary" @click="show=!show">Alert</button>
                <br><br>
                <transition>
                    <dir class="alert alert-info" v-if="show">This is some info</dir>
                </transition>
                    
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                show: false
            }
        }
    }
</script>

<style>

</style>
