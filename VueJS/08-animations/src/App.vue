<template>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
                <h1>Animations</h1>
                <button class="btn btn-primary" @click="show=!show">Alert</button>
                <br><br>
                <transition name="fade"> <!-- Vue will attach CSS classes: fade-enter, fade-enter-active, fade-leave & fade-leave-active -->
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

<style scoped>
    /* Vue will analyze this CSS classes to determine how long will be the animations */
    .fade-enter { /* Enter the DOM: CSS attached for one frame at the beginning */
        opacity: 0;
    }

    .fade-enter-active { /* Enter the DOM: CSS attached for the whole element at animation time */
        transition: opacity 1s;
        /* opacity: 1 */ 
        /* Maybe you will be tempted to put here the destiny value of opacity. 
        Wrong! remember the opacity 0 only it's determined for the first frame, after the first frame
        all this CSS class will be applied, so putting here 1 will pass directly from 0 to 1 with no apparent transition */
    }

    .fade-leave { /* Leave the DOM: CSS attached for one frame at the beginning */
        /*opacity: 1; This is the default value, so we don't need to specify it */
    }

    .fade-leave-active { /* Leave the DOM: CSS attached for the whole element at animation time */
        transition: opacity 1s; /* Here we are telling to change opacity during 1 sec. until the opacity value will be 0*/
        opacity: 0;             /* again: destiny value for opacity property */
    }
</style>
