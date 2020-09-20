<template>
<div>

    <h3>In Axios Component</h3>
    <img :src="imageSource" />
    <br><br>
    <button @click="GetRemoteCharacter()">Jo, tio</button>
</div>
</template>
<script> 
export default {
    name: 'AxiosComponent',
    data() {
        return {
            imageSource: String
        }
    },
    created(){
        this.GetRemoteCharacter();
    },
    methods:{

        GetRemoteCharacter(){
            let num = this.generateRandomNumber(30);
            this.$http.get('/character/' + num)
                        .then(result => {                                
                                this.imageSource = result.data.image;
                            }, error => {
                                console.error(error);
                            });
        },
        generateRandomNumber(i) {
            return Math.ceil(Math.random() * i);
        }
    }
}
</script>