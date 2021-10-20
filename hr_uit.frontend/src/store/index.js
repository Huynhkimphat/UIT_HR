import Vue from 'vue'
import Vuex from 'vuex'

// Import Root Store
import rootGetters from './getters'
import rootMutations from './mutations'
import rootActions from './actions'

// Import Employee Store
import employeeStore from './Employee/employee'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    employeeStore,
  },
  state() {
    return {
    }
  },
  getters: rootGetters,
  mutations: rootMutations,
  actions: rootActions,
})
