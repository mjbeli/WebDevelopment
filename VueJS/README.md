# VueJS Fundamentals

Welcome! this is a series of little projects in Vue with the porpuose to show how it works. From basic to advanced features, the projects are created to show very focused functions.

03-advanced-components: slots & dynamic components.

### Project creation

These projects has been created using Vue CLI 3:

 - Install Vue CLI like this: ```npm install -g @vue/cli```
 - Create a project like this: ```vue create <<project_name>>```

###### Project setup
```
npm install
```

Compiles and hot-reloads for development: ```npm run serve```
Compiles and minifies for production: ```npm run build```

Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).

### Consume an API

Install axios: ```npm install axios```
In src/main.js add this:
```javascript
import axios from "axios";
Vue.prototype.$http = axios; // now this.$http contains an instancie of axios, not vue-resource
```




