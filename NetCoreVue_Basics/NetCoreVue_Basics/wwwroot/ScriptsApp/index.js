Vue.component('todo-item', {
    props: ['todo'],
    template: '<li>{{todo.text}}</li>'
})


var app = new Vue(
    {
        el: '#app',
        data: {
            mensaje: 'Hola desde Vue!',
            groceryList: [{ id: 0, text: 'Vegetables' },
            { id: 1, text: 'Cheese' },
            { id: 2, text: 'meat' }]
        },
        methods: {
            reverseMensaje: function () {
                this.mensaje = this.mensaje.split('').reserse().join('')
            }
        }

    }
);
