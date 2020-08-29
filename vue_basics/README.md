### Consume an API

Install axios: ```npm install axios```
In src/main.js add this:
```javascript
import axios from "axios";
Vue.prototype.$http = axios; // now this.$http contains an instancie of axios, not vue-resource
```




