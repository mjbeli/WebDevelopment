const ModuleTareas = {
    namespaced: true, // if this is false or omitted, this vuex will be stored in the global namespace.
    state: {
        tareasState: ['task1', 'task2', 'task3'],
        moduleCounter: 0
    },
    mutations: {
        incrementModuleCounter: function(state, variable) { // Always receive state as first parameter.
            state.moduleCounter += variable;
        }
    },
    actions: {

    },
    getters: {

    }
}

export default ModuleTareas;