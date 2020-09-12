<template>
<div>
    <p>Counter is: {{ counter }}</p>
    <p>DoubleCounter is: {{ doubleCounter }}</p>
    <p>Number of clicks: {{ stringCounter }}</p>
</div>
</template>

<script>
    import { mapGetters } from 'vuex'; // Stablished name by Vuex

    export default {
        // Now instead of splicity write our computed properties we can
        computed: {
            // This is a function that receives an array. 
            // This array specify the getters we want use in this component.
            ...mapGetters([
                'doubleCounter', // automatic mapping
                'stringCounter',
                'counter'
            ]),
            myOwnComputedProperty(){
                return '';
            }
        }
    }
</script>