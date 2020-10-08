# VueJS Fundamentals

Welcome! this is a series of little projects in Vue with the porpuose to show how it works. From basic to advanced features, the projects are created to show very focused functions.

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

### Index-content
* [01-essentials:](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#01-essentials) 
  * [01.01 Interpolation](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0101-interpolation)  
  * [01.02 v-bind](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0102-v-bind)  
  * [01.03 methods](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0103-methods)  
    * [01.03.01 How methods works](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#010301-how-methods-works)
    * [01.03.02 Accessing data from methods](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#010302-accessing-data-from-methods)  
  * [01.04 v-html](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0104-v-html)  
  * [01.05 v-on](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0105-v-on)  
  * [01.06 v-once](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0106-v-once)
  * [01.07 event modifiers](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0107-event-modifiers)
  * [01.08 v-model](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0108-v-model)
  * [01.09 computed properties](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0109-computed-properties)
    * [01.09.01 setters for computed properties](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#010901-setters-for-computed-properties)
  * [01.10 watchers](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0110-watchers)
    * [01.10.01 watch arrays and objects](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#011001-watch-arrays-and-objects)
    * [01.10.02 execute watcher in load](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#011002-execute-watcher-in-load)  
  * [01.11 v-bind with class attribute](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/01-essentials#0111-v-bind-with-class-attribute)
* [03-advanced-components:](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/03-advanced-components) slots & dynamic components. 
  * [03.01 Slots](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/03-advanced-components#0301-slots)  
  * [03.02 Dynamic Component](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/03-advanced-components#0302-dynamic-component)
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
     * [06.05.01 Query parameters](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/06-routing/README.md#060501--query-parameters)
     * [06.05.02 Optional parameters](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/06-routing/README.md#060502--optional-parameters)    
  * [06.06 Nested routes](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0606-nested-routes)
  * [06.07 Create dymanic links](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0607-create-dymanic-links)
  * [06.08 Redirections](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#0608-redirections)
  * [06.09 Guards](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/06-routing/README.md#0609-guards)
  * [06.10 Lazy loads with webpack](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/06-routing/README.md#0610-lazy-loads-with-webpack)
 * [07-vuex](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/06-routing#06-routing)
   * [07.01 Setup & basics](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#0701-setup--basics)
   * [07.02 Getters](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#0702-getters)
     * [07.02.01 Helpers for Getters](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#070201-helpers-for-getters)
   * [07.03 Mutations](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#0703-mutations)
   * [07.04 Actions](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#0704-actions)
   * [07.05 Arguments to Mutations & Actions](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#0705-arguments-to-mutations--actions)
   * [07.06 v-model with cental state](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#0706-v-model-with-cental-state)
   * [07.07 Patterns in store](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#0707-patterns-in-store)
     * [07.07.01 Modules](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#070701-modules)
     * [07.07.02 Splitting central code](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/07-vuex/README.md#070702-splitting-central-code)
* [08-animations](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#08-animations)
   * [08.01 Basics setup](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0801-basics-setup)  
   * [08.02 CSS Transitions](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0802-css-transitions)
   * [08.03 CSS Animations](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0803-css-animations)
   * [08.04 CSS Transitions & Animations together](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0804-css-transitions--animations-together)
   * [08.05 Animation initial load](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0805-animation-initial-load)
   * [08.06 Transition between elements](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0806-transition-between-elements)
   * [08.07 Javascript hooks](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0807-javascript-hooks)
   * [08.08 Animating dynamic components](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0808-animating-dynamic-components)
   * [08.09 Animating list](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/08-animations#0809-animating-list)
* [09-axios](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/09-axios#09-axios)
   * [09.01 Basics setup](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/09-axios#0901-basics-setup)
   * [09.02 Doing basic request](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/09-axios#0902-doing-basic-request)
   * [09.03 Global configuration](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/09-axios#0903-global-configuration)
   * [09.04 Interceptors](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/09-axios/README.md#0904-interceptors)
   * [09.05 Axios custom instances](https://github.com/mjbeli/WebDevelopment/blob/master/VueJS/09-axios/README.md#0905-axios-custom-instances)
* [10-composition-api](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#10-composition-api)
   * [10.01 Introduction](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1001-introduction)
   * [10.02 Reactive data](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1002-reactive-data)
     * [10.02.01 ref](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#100201-ref)
     * [10.02.02 ref & complex objects](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#100202-ref--complex-objects)
     * [10.02.03 Reactive](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#100203-reactive)
   * [10.03 Methods](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1003-methods)
   * [10.03 Methods](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1003-methods)
   * [10.04 v-model in composition API](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1004-v-model-in-composition-api)
   * [10.05 Computed properties](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1005-computed-properties)
   * [10.06 Watchers](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1006-watchers)
   * [10.07 Components & props](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1007-components--props)
     * [10.07.01 Send props to component](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#100701-send-props-to-component)
     * [10.07.02 Receive props in component API](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#100702-receive-props-in-component-api)
   * [10.08 Context in setup](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1008-context-in-setup)
   * [10.09 Provide & inject](https://github.com/mjbeli/WebDevelopment/tree/master/VueJS/10-composition-api#1009-provide--inject)
   
     
     
   
   
     


