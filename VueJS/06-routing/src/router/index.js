/* THIS FILE WAS AUTOMATICALY GENERATY WHEN INSTALING RUOTER USING VUE CLI: vue add router */
import Vue from 'vue'
import VueRouter from 'vue-router'
import User from '../components/user/User.vue'
import UserStart from '../components/user/UserStart.vue'
import UserDetail from '../components/user/UserDetail.vue'
import UserEdit from '../components/user/UserEdit.vue'
import Home from '../components/Home.vue'

Vue.use(VueRouter)

// This constant it's an array of objects. Each object will be a route defined by several specific attributes.
const routes = [{
        path: '', // If the path is empty, it's the first page visited. Our landing page.
        name: 'Home',
        component: Home // component we want to load when visited the path. We need to import de component.
    },
    {
        path: '/user/:id', // The path of the route. Will match with /user/something
        props: true,
        name: 'User',
        component: User // component we want to load when visited the path. We need to import de component.
    },
    {
        path: '/user',
        name: 'User',
        component: User,
        // this property is an array of routes that will be sub-routes of '/user' route
        children: [
            // If the path in a subroute starts with a '/' it will be appended directly after the domain. 
            // If don't starts with '/' it will be appended to the parent route '/user'
            { path: '', component: UserStart },
            { path: 'us/:id', component: UserDetail, props: true },
            { path: 'us/:id/edit', name: 'UserEdit', component: UserEdit, props: true }
        ]
    }
]

// This is the unique router instance of the application. After this, all is about switching components.
const router = new VueRouter({
    routes,
    mode: 'history' // the default mode is 'hash'
})

export default router // export the const router defined early.