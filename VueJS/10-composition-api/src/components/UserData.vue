<template>
    <h3>{{ userData }}</h3>    
</template>
<script>
    import { computed, inject } from 'vue';

export default {
    props: ['userName'],

    // setup it's a function that accepts 2 parameters
    // the first one it's props paramenter, it's an object with attrib. that are the same as props name.
    // if the component don't receive props, the props object will be empty.
    setup(props, context){ 
        const injectedAge = inject('userAge'); // use the same key that was used in the provide function!

        const userData = computed(function(){
            return props.userName + ' ' + injectedAge.value; // can use injected values as a normal ref (with .value)
        });
        
        // const userData = props.userName + ' ' + props.age; --> The changes will not be updated to the template.
        console.log(context);

        return {
            userData, injectedAge
        }
    }
}
</script>