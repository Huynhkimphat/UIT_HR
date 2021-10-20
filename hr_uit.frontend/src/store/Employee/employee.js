import employeeMutations from './employeeMutations'
import employeeGetters from './employeeGetters'
import employeeActions from './employeeActions'

export default {
  state: () => ({
    employees: [],
  }),
  getters: employeeGetters,
  mutations: employeeMutations,
  actions: employeeActions,
}
