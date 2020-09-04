# 05-filters-mixins


**IMPORTANTE**
> En Vue 3 los filtros desaparecen.

```
<!-- before -->
{{ msg | format }}

<!-- after -->
{{ format(msg) }}
```

Motivos:
 - La funcionalidad que dan los filtros pueden ser fácilmente replicadas con funciones o propiedades computadas.
 - Los filtros requieren una micro sintaxis propia que rompe con la filosofía de que todas las expresiones son Javascript, por lo tanto tienen un coste en aprendizaje e implementación.
 - Agregan complejidad al soporte del IDE (de nuevo, porque no es javascript).

> En Vue 3 los mixins siguen soportados pero se consideran inseguros.

Los mixins se consideran un antipatrón:
  - Conflictos entre nombres
  - Dependencias implícitas: los componentes pueden usar propiedades de los mixins pero también ocurre al revés, un mixin puede asumir que el componente tiene una propiedad ¿y si queremos cambiar el nombre de una propiedad? ¿tendremos que buscar en todos los mixins por si se usa esa propiedad?.
  
 
### 05.01 Filters

Filters apply on a outcome and trasnform the data. No the data itself, only transform what the user sees.

We can create a filters section under the script section, so there we can create the filters used in that component. The filters are functions that receive a param 'value', that is the data we want transform:

```javascript
export default {
  name: 'App',
  data(){
    return {
      text: 'Hola mundo'
    }      
  },
  filters:{
    myCustomUppercase(value){
        return value.toUpperCase();
    }
  }
}
```

We can use the filter like using the pipe character:
```html
<p>{{ text | myCustomUppercase}}</p> <!-- This dont transform text, only transform the output -->
```

We can defined a filter globaly in the main.js like this:
```javascript
Vue.filter('my-custom-lowarecase',
    function(value) {
        return value.toLowerCase();
    });
```

We can chain differents filters like this. It applies one by one from left to right:
```html
<p>{{ text | myCustomUppercase | my-custom-lowarecase }}</p>
```

### 05.01 Mixins

To avoid repeated code, the mixins are a way to distribute functionalities. A mixin object can contain ANY component option (including data, methods, computed, watchers,...).

This is how we can define a mixin:
```javascript
export const myMixin = {
    computed: {
        myComputedPropertyInMixin() {
            return 'From the mixin';
        }
    }
}
```

And this is how we can use it inside a component:
```javascript
import { myMixin } from './myMixin' 

export default {
  mixins: [myMixin] // this is an array that specifies all mixins we want to merge in this component.
}
```

The hooks (events) defined in the mixin will execute BEFORE the hooks defined inside the component. So always the component has the last word and can overwrite anything.

We can define a global mixin like this:
```javascript
Vue.mixin({
  created: function () {
    var myOption = this.$options.myOption
    if (myOption) {
      console.log(myOption)
    }
  }
})
```

IMPORTANT: try to use global mixin the least possible, because affects all Vue instances, including components of third parties.

For hooks lifecycle: First global mixins, then local mixins (defined with the array), last hook of the component.
