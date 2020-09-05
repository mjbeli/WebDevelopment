# 06-routing

### 06.01 Setup & start

Using npm:

```
npm install --save vue-router
```

Using Vue CLI:
```
vue add router
```
The last one will add the necesary code in main.js, add a file index.js in router folder and also will overwrite your App.vue.

> src/router/index.js
```javascript
import VueRouter from 'vue-router'

Vue.use(VueRouter)

// This constant it's an array of objects. Each object will be a route defined by several specific attributes.
const routes = [ /*...*/ ];

// This is the unique router instance of the application. After this, all is about switching components.
const router = new VueRouter({
    routes
})

export default router // export the const router defined early.
```

> /src/main.js

```javascript
import router from './router' // This import the router const defined in: src/router/index.js

new Vue({
    el: '#app',
    router, // Add the router defined in src/router/index.js to de main Vue instance.
    render: h => h(App)
})
```

### 06.02 Basics

The place where the router will load the components it's in the tag ```<router-view></router-view>```
Is this example this tag is in our document App.vue

How to add routes in src/router/index.js

```javascript
const routes = [{
        path: '/user', // The path of the route.
        name: 'User',
        component: User // component we want to load when visited the path. We need to import de component.
    },
    {
        path: '', // If the path is empty, it's the first page visited. Our landing page.
        name: 'Home',
        component: Home // component we want to load when visited the path. We need to import de component.
    }
]
```

### 06.03 Hash Vs History

The default mode is hash mode. In this mode the URL has this apareance (always a hashtag after the domain):
```
http://localhost:8080/#/
http://localhost:8080/#/user
```

Without the hashtag, each enter in our keyboard send a request to the server, this avoid the Single Page Application behaviour. We don't want to go to the server! we want to handle the request in the local page (except the first time, that we need to get the SPA of course).

With the hashtag, the part before the hashtag is sended to the server, this return to local page the index.html; the part after the hashtag is handle by de local javascript

What can we do to use the normal URL and still has this desirable behaviour?
Configure the server in a way that always send the index.html (even in 404 cases). Then in the returned page Vue will take care of parse the url.

For activate the history mode, pass an argument to the router instance like this:

```javascript
// This is the unique router instance of the application. After this, all is about switching components.
const router = new VueRouter({
    routes,
    mode: 'history' // the default mode is 'hash'
})
```

Note: our localhost in webpack it's automatically configured to return always index.html so it will work well with history mode. It will be necessary to configure our production server.
Doc: https://router.vuejs.org/guide/essentials/history-mode.html

