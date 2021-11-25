import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate'

// Import Root Store
import rootGetters from './getters'
import rootMutations from './mutations'
import rootActions from './actions'

// Import Modules Store
import employeeStore from './Employee/employee'
import holidayStore from './Holiday/holiday'
import attendanceStore from './Attendance/attendance'
import dayOffLetterStore from './DayOffLetter/dayOffLetter'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    employeeStore,
    holidayStore,
    attendanceStore,
    dayOffLetterStore,
  },
  state() {
    return {
      isLoggedIn: null,
      error: null,
      token: null,
      role: null,
      userId: null,
      username: null,
    }
  },
  getters: rootGetters,
  mutations: rootMutations,
  actions: rootActions,
  plugins: [createPersistedState({
    storage: window.sessionStorage,
  })],
})
