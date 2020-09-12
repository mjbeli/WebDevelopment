<template>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
                <h1>Vuex</h1>
                <app-result></app-result>
                <hr>
                <app-counter></app-counter>
                <app-another-result></app-another-result>
                <app-another-counter></app-another-counter>
                <hr>
                <hr>
                <hr>
                <!--computed properties only returns a value, for use v-model the computed prperty must have set (in addition to traditional get) -->
                <input type="text" v-model="computedValue"> 
                <p>{{value}}</p>
            </div>
        </div>
    </div>
</template>

<script>
    import Counter from './components/Counter.vue';
    import Result from './components/Result.vue';
    import AnotherResult from './components/AnotherResult.vue';
    import AnotherCounter from './components/AnotherCounter.vue';

    export default {
        components: {
            appCounter: Counter,
            appResult: Result,
            appAnotherResult: AnotherResult,
            appAnotherCounter: AnotherCounter
        },
        computed: {
            computedValue: {
                get(){
                    return this.$store.getters.value; // normal usage of a computed property.
                },
                set(value){
                    this.$store.dispatch('updateValue', value); // setter for modify the central state of the application.
                }
            }
        }
    }
</script>

