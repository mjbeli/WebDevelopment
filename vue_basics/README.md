# vue_basics

This project has been created using Vue CLI 3:

 - Install Vue CLI like this: ```npm install -g @vue/cli```
 - Create a project like this: ```vue create vue_basics```

### Project setup
```
npm install
```

Compiles and hot-reloads for development: ```npm run serve```

Compiles and minifies for production: ```npm run build```

### Consume an API

Install vue-resource: ```npm install vue-resource --save```
In src/main.js add this:
```javascript
import VueResource from 'vue-resource';
Vue.use(VueResource);
```



Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).
