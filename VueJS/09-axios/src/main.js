import Vue from 'vue'
import App from './App.vue'
import axios from 'axios';

Vue.prototype.$http = axios; // now this.$http contains an instancie of axios, not vue-resource

// Axios it's the same object in all the application
// This config will apply to any request
axios.defaults.baseURL = 'https://rickandmortyapi.com/api'; // this will be the basic URL apply to all requests

// Axios will send some specific headers, but we can customize with header object.
// axios.defaults.headers.get['HeaderForGets'] = 'Value'; --> this header will be sended only for Get request.

// header.common will be applied to any request, no matter the type of the request.
axios.defaults.headers.common['Authorizarion'] = 'MyAuthTokenSendedInEveryRequest';

// Add a interceptor of type request will execute a function every time a request leave the app.
// .use() for add an interceptor. 
// The function receive the request configuration as an argument 
// You must always return that config, otherwise you will block the request.
axios.interceptors.request.use(config => {
    // Code here can manipulate config.headers so it can be customized.
    console.log('Request interceptor', config);
    return config;
});

// Add a interceptor of type response will execute a function every time a request returns to the app.
// You must always return the response, otherwise you will block the request.
axios.interceptors.response.use(resp => {
    console.log('Response interceptor', resp);
    return resp;
});

// To delete interceptors use eject and the interceptor ID that is returned in the use functions
// axios.interceptors.request.eject(reqInterceptorId);
// axios.interceptors.response.eject(resInterceptorId);


new Vue({
    el: '#app',
    render: h => h(App)
})