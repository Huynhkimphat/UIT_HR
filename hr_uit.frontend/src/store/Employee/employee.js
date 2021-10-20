import axios from 'axios'
import API_URL from '../API_URL'

const employee = {
  state: () => ({
    employees: [],
  }),
  mutations: {
    getEmployees(state, payload) {
      state.employees = payload
    },
  },
  actions: {
    async getEmployees(context) {
      const result = await axios.get(`${API_URL}/employee/all`)
      context.commit('getEmployees', result.data)
    },
  },
  getters: {
    getEmployees(state) {
      return state.employees
    },
  },
}
export default employee
