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
import User from '../components/user/User.vue'
import Home from '../components/Home.vue'

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

### 06.04 Navigation

##### Links
Instead using anchor tag <a>, let's use router-link provide for VueJs:

```html
<!-- 
    <a class="nav-link" href="#">Active</a> 
    If we use <a> tag, the link will send a request to the server, then the server
    will be a behaviour that we expected and the touter will handle the request,
    but in first place, it's useless to leave the application to go to the server.
    Instead using <a> we can use an alternativo provided for VueJs: <router-link></router-link>
    This tag will produce an <a> tag a the end but with a click listener attached to it that
    ovewrites the default behaviour of send a request to the server.
-->
    <router-link to="/">Home</router-link>
```

Specifing the tag attribute to router-link we can define the element we want to render. By the default the rendered element will be <a> but we can define as <li> like this:

```html
<router-link to="/" tag="li"><a>Home</a></router-link>
```

This way the active styles will be applied to the <li> element instead of <a>

##### Code

> In <script> of our component:

```javascript
methods: {
    navigateToHome(){            
        // This push add the route to the stack navigation so it's preserve the behaviour of the
        // back and forward buttons. 
        // this.$router.push('/'); 
        this.$router.push({ name: 'Home' }); // We can also pass an object to push.
    }
}
```

The object we can pass to push method is the same that will use to generate dynamic links. It can receive path, name and params attributes.


##### Navigate to anchors

Imagine we have an element like this at the bottom of our component:

```html
<p id="data">Some data at the bottom of the page</p>
```

The default behavior of the browser let us to navigate to this element accessing to the url:
```
http://localhost:8080/user/us/1/edit?locale=en&q=100#data
```

When generate the link with router-link we can pass an attrib. called hash:

```html
<router-link tag="button" 
            :to="{ 
                name: 'UserEdit', 
                params: { id: id }, 
                query: { locale: 'en', q: 100 },
                hash: '#data'
                }">
            Edit User</router-link>
```

We can define a function into router object to define scroll behaviour. The function expect to return coordinades or a selector to scroll.

``` javascript
const router = new VueRouter({
    routes,
    mode: 'history', 
    scrollBehavior(to, from, savedPosition){ /* savedPosition determine if the browser saves the position of the scroll so when back to previous page scroll to de position */
        if(to.hash){
            return { selector: to.hash }; // scroll to selector in hash attrib.
        }
    }
})
```

### 06.05 Parameters

Add dinamyc parameters to an url like this:

```javascript

const routes = [{
        path: '/user/:id', // Will match with /user/something
        name: 'User',
        component: User 
    }
    /* ...*/
]
```

From now the route ```/user``` will not match, so it will stop working. We must update the links like this:
```html
<router-link to="/user/10">User</router-link>
```

To retreive the id parameter in the component:
```javascript
data(){
    return {
        localId: this.$route.params.id // Watch Out: this is de route object, different from this.$router
    }
}
```

Be careful! when navigate to the same component but only changes the route, the component it's not recreated. So if we first access to, for example, ```/user/10``` and then to ```/user/23``` the ```this.localId``` won't change.

To avoid this problem and, honestly, to a better reading code, we can receive a dynamic parameter as a prop this way:

```javascript
const routes = [{
        path: '/user/:id', // Will match with /user/something
        props: true,
        name: 'User',
        component: User 
    }
    /* ...*/
]
```

```javascript
export default {
    props: ['id'],
    /****/
}
```

##### Query parameters

The attib. 'to' can receive another object in 'query' to define query parameters in the url:
```html
<!-- attribute 'to' needs the colon to receive an object -->
<router-link 
        tag="button" 
        :to="{ name: 'UserEdit', params: { id: id }, query: { locale: 'en', q: 100 } }">
        Edit User</router-link>
```

In the component we can access these query parameters using $route object:
```html
<p> Locale: {{ $route.query.locale }}</p>
<p> q: {{ $route.query.q }}</p>
```

### 06.06 Nested routes

We can add sub-routes in a component, for example add user detail and user edit as child of user component.

> Inside routes variable that define the routes of the application 
```javascript
{
    path: '/user',
    name: 'UserList',
    component: User,
    // children property is an array of routes that will be sub-routes of '/user' route
    children: [
            // If the path in a subroute starts with a '/' it will be appended directly after the domain. 
            // If don't starts with '/' it will be appended to the parent route '/user'
            { path: '', component: UserStart },
            { path: 'us/:id', component: UserDetail },
            { path: 'us/:id/edit', component: UserEdit }
        ]
    }
```

We need a place to load the components defined in the sub-routes, because the ```<router-view></router-view>``` tag indicates the place where the root routes is loaded, not nested routes.

Well, the only thing is to put the same tag in the component of the parent route. So the nested routes will be loader there. You will see that when the parent component is showed and the route match with a children route, the component of that children route will be loaded in the place where router-view tag was placed.

### 06.07 Create dymanic links

If we assign a name to a route like this:
```javascript
{ path: 'us/:id/edit', name: 'UserEdit', component: UserEdit, props: true }
```

We can referer that name in any router-link to generate a link:
```html
<!-- attribute 'to' needs the colon to receive an object -->
<router-link 
        tag="button" 
        :to="{ name: 'UserEdit', params: { id: id } }">
        Edit User</router-link>
```

The ```to``` attribute can receive an object with a set of parameters that VueJs will recognoize. The name attrib refers to the name given in the routes var and the params is an object of key-value pairs where the key is the parameter in the path of the router ```us/:id/edit``` and the value is what we want to assign (in this case a prop).

### 06.08 Redirections

> In index.js where url are specified

```javascript
const routes = [
    /* bla bla bla */
    // { path: '/redirect', redirect: '/user' } // this redirects the url /redirect to /user
    { path: '/redirect', redirect: { name: 'Home' } } // In this object we can add parameters, component, props true,... 
]
```

To capture all the url that doesn't exists and rdirecto to a 404 page:
```javascript
const routes = [
    /* bla bla bla */
    {
        path: '*', // Match with anything that hasn't been handle in previous routes
        redirect: { name: 'Home' } // In this object we can add parameters, component, props true,...
    }
]
```

### 06.08 Guards

We can pass a function to ```router.beforeEach()``` and it will be execute before each router action. Inside this function we can use:
 - ```next();``` to indicate that the router keep navigating to the destiny.
 - ```next(false);``` to indicate the router to abort the navigation and stay where we are.
 - ```next({ name: 'Home', props: true });``` to indicate the router to navigate to the tipical object that define a route.

 Watch out! the beforeEach() executes in every router action, so use it carefully.

```javascript
const router = new VueRouter({
    routes,
    mode: 'history'
});


router.beforeEach(
    (to, from, next) {
        console.log ('be careful, this calls in each router action');
        next(); // Important! don't forget the next() to continue 
                // the router navigation after some checks.
    }
);
```

To protecto only certain route, we can use the ```beforeEnter``` attrib. when defining a route. The function receive the same as beforeEach:

```javascript
const routes = [
        {
        path: '', 
        name: 'Home',
        component: Home,
        beforeEnter: (to, from, next) => {
            next();
        }
    }
    ]
```

Also we can implement a guard in the component itself using a new event provide for the router called beforeRouteEnter(). It's like a lifecycle hook.

```javascript
<script>
export default {
    data(){
        return {
            data: 'my data'
        }
    },
    beforeRouteEnter(to, from, next){
        // if here we don't call next(); this component won't be loaded
        // this.data --> this is not available here, because this component 
        // it's not loaded or created yet. 
        // Only have access to the component from and the route destiny you are navigating.
        next();
        // we can pass a callback that will be execute after the component has been created:
        next( vi => {
            vi.data; // here it's possible to access to the Vue instance.
        });
    }
}
</script>
```

To check if an user can leave a route, the only place to check it's inside the component we want to leave, that's becouse in a global level it might be late to check, the navigation would be started it's journey.

The same way, to allow the navigation we must call next() method.

```javascript
<script>
export default {
    data(){
        return {
            data: 'my data'
        }
    },
    beforeRouteLeave(to, from, next){
        // if here we don't call next(); this component won't be leaved
        // this.data --> this is available here.        
        next();        
    }
}
</script>
```






