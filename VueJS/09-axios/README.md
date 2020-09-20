# 09-axios

### 09.01 Basics setup

Install axios: ```npm install --save axios```

For import axos globally:
> In src/main.js add this:
```
import axios from 'axios';
Vue.prototype.$http = axios; // now this.$http contains an instancie of axios, not vue-resource
```

Or we can import in each component we use axios:
> In script tag inside a component:
```
import axios from 'axios';
this.$axios.get(...);
```

### 09.02 Doing basic request

Now we can do a basic get request:
```javascript
GetRemoteCharacter(){
    let num = this.generateRandomNumber(30);
    this.$http.get('https://rickandmortyapi.com/api/character/' + num)
                    .then(result => {                                
                        this.imageSource = result.data.image;
                    }, error => {
                        console.error(error);
                    });
}
```

A post request has 2 (or 3) arguments:
 - The url
 - The data sending to the post request.
 - (Optional) A javascript object with additional configuration

Note that all the protocols (get, post, put, delete) returns a promise.

### 09.03 Global configuration

Axios has an object that allows us define some default configuration: ```axios.defaults```

> In .src/main.js
```javascript
import axios from 'axios';

// Axios it's the same object in all the application
// This config will apply to any request
axios.defaults.baseURL = 'https://rickandmortyapi.com/api'; // this will be the basic URL apply to all requests
```

No que can do this and will work!
```javascript
this.$http.get('/character/' + num)
            .then(result => {                                
                this.imageSource = result.data.image;
            }, error => {
                console.error(error);
            });
```

Setting header:
> In .src/main.js 
```javascript
// Axios will send some specific headers, but we can customize with header object.
// axios.defaults.headers.get['HeaderForGets'] = 'Value'; --> this header will be sended only for Get request.

// header.common will be applied to any request, no matter the type of the request.
axios.defaults.headers.common['Authorizarion'] = 'MyAuthTokenSendedInEveryRequest';
```

### 09.04 Interceptors

Interceptor are functions that should be executed in each request that leaves the application or every response that returns to the application.

> In .src/main.js 
```javascript
import axios from 'axios';

// Add a interceptor of type request will execute a function every time a request leave the app.
// .use() for add an interceptor. 
// The function receive the request configuration as an argument 
// You must always return that config, otherwise you will block the request.
axios.interceptors.request.use(config => {
  // Code here can manipulate config.headers so it can be customized.
  return config;
});
```

> In .src/main.js 
```javascript
// Add a interceptor of type response will execute a function every time a request returns to the app.
axios.interceptors.response.use(response => {

});
```

To delete interceptors use eject and the interceptor ID that is returned in the use functions:

```javascript
axios.interceptors.request.eject(reqInterceptorId);
axios.interceptors.response.eject(resInterceptorId);
```

### 09.05 Axios custom instances

Instead of using always the same axios instance we can create an instance like this:

```javascript
import axios from 'axios';

const myAxiosInstance = axios.create({
    baseURL: 'New URL BASE'
});

myAxiosInstance.defaults.headers.common['SOMETHING'] = 'someValue';

export default myAxiosInstance; 
// Now we can use myAxiosInstance anywhere in our application like this: 
// import axiosInstance from 'pathToFile/FileName';
```

