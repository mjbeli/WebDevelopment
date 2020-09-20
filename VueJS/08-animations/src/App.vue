<template>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
                <h1>Animations</h1>
                <button class="btn btn-primary" @click="show=!show">Alert</button>
                <br><br>
                <p>Simple transition</p>
                <transition name="fade"> <!-- Vue will attach CSS classes: fade-enter, fade-enter-active, fade-leave & fade-leave-active -->
                    <div class="alert alert-info" v-if="show">This is some info</div>
                </transition>
                <br><br>
                <p>Transition & animation together</p>
                <transition name="slide"> <!-- Vue will attach CSS classes: slide-enter, slide-enter-active, slide-leave & slide-leave-active -->
                    <div class="alert alert-info" v-if="show">This is some info</div>
                </transition>
                <br><br>
                <p>Fade when it's loaded</p>
                <transition name="fade" appear> 
                    <div class="alert alert-info" v-if="show">This is some info</div>
                </transition>
                <br><br>
                <p>Transition between elements</p>
                <transition name="fade-v2" mode="out-in"> 
                    <div class="alert alert-info" v-if="show" key="info">This is some info</div>
                    <div class="alert alert-warning" v-else key="warning">This is some Warning!</div>
                </transition>
                <hr>
                <hr>
                <button class="btn btn-primary" 
                        @click="selectedComponent == 'sucess-alert' ? 
                                selectedComponent='danger-alert' : 
                                selectedComponent = 'sucess-alert'">
                Toggle Component</button>
                <br>
                <br>
                <transition name="fade" mode="out-in">
                    <component :is="selectedComponent"></component>
                </transition>
                <hr>
                <hr>
                <button class="btn btn-primary" @click="addItem">Add Item</button>
                <br><br>
                <ul class="list-group">
                    <transition-group name="slide">
                        <li class="list-group-item" 
                            v-for="(number, index) in numbers" 
                            :key="number" 
                            @click="removeItem(index)"
                            style="cursor: pointer">{{number}}</li>
                    </transition-group>
                </ul>
                <br><br><br><br>    
            </div>
        </div>
    </div>
</template>

<script>
    import dangerAlert from './components/DangerAlert'
    import sucessAlert from './components/SuccessAlert'

    export default {
        data() {
            return {
                show: true,
                selectedComponent: 'sucess-alert',
                numbers: [1, 2, 3, 4, 5]
            }
        },
        components:{ dangerAlert, sucessAlert },
        methods:{
            addItem(){
                const pos = Math.floor(Math.random() * this.numbers.length);
                this.numbers.splice(pos, 0, this.numbers.length +1);
            },
            removeItem(index){
                this.numbers.splice(index,1);
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





    .slide-enter {
        /* transform: translateY(30px); This it's not necessary because it's defined in keyframe animation */
        opacity: 0;
    }

    .slide-enter-active {
        animation: slide-in 1s ease-out forwards; /* slide-in is the name of keyframe animation */
        transition: opacity .5s;
    }

    .slide-leave { 
        /* again it's not necessary because the stating position it's defined in keyframe animation */
    }

    .slide-leave-active { 
        animation: slide-out 1s ease-out forwards;
        transition: opacity 1s;
        opacity: 0;
        position: absolute; /* Add for transition-group animate removing element */
    }

   
    .slide-move{  /* For transition-group */
        transition: transform 1s; /* Here we are telling Vue: when the transition of an element changes, animated it for 1 sec.  */
    }

    @keyframes slide-in {
        from {
            transform: translateY(30px); /* Start of the animation: +30px in Y axis (vertical) */
        }
        to {
            transform: translateY(0); /* End of the animation, the real position defined for the element in our document */
        }
    }

    @keyframes slide-out {
        from {
            transform: translateY(0); /* Start of the animation, the real position defined for the element in our document */
        }
        to {
            transform: translateY(30px); /* End of the animation: +30px in Y axis (vertical) */            
        }
    }




    .fade-v2-enter { opacity: 0; }

    .fade-v2-enter-active {  transition: opacity 3s; }
 
    .fade-v2-leave-active {  
        transition: opacity 3s; 
        opacity: 0;             
    }
</style>


