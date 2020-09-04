/* THIS FILE WAS AUTOMATICALY GENERATY WHEN INSTALING RUOTER USING VUE CLI: vue add router */
import Vue from 'vue'
import VueRouter from 'vue-router'
import User from '../components/user/User.vue'
import Home from '../components/Home.vue'

Vue.use(VueRouter)

// This constant it's an array of objects. Each object will be a route defined by several specific attributes.
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

// This is the unique router instance of the application. After this, all is about switching components.
const router = new VueRouter({
    routes
})

export default router // export the const router defined early.