# VueJS Fundamentals

Welcome! this is a series of little projects in Vue with the porpuose to show how it works. From basic to advanced features, the projects are created to show very focused functions.

* [03-advanced-components:](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/03-advanced-components) slots & dynamic components.

* [04-forms](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/04-forms#04-forms)

  * [04.01-bootstrap-vue](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/04-forms#0401-bootstrap-vue)
  
  * [04.02-binding](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/04-forms#0402-binding)
  
* [05-filters-mixins]() Filters are deprecated in Vue3 and mixins are consider anti-pattern

* [06-routing](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#06-routing)

  * [06.01 Setup & start](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0601-setup--start)
  
  * [06.02 Basics](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0602-basics)
  
  * [06.03 Hash Vs History](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0603-hash-vs-history)
  
  * [06.04 Navigation](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0604-navigation)
  
  * [06.05 Parameters](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0605-parameters)
  
  * [06.06 Nested routes](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0606-nested-routes)
  
  * [06.07 Create dymanic links](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0607-create-dymanic-links)
  
  * [06.08 Redirections](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0608-redirections)
  
  * [06.09 Guards](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/06-routing/README.md#0609-guards)
  
  * [06.10 Lazy loads with webpack](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/06-routing/README.md#0610-lazy-loads-with-webpack)
  
     
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




