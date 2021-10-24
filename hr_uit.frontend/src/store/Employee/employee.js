import employeeMutations from './employeeMutations'
import employeeGetters from './employeeGetters'
import employeeActions from './employeeActions'

export default {
  namespaced: true,
  state: () => ({
    employees: [],
    createResponse: {},
    deleteResponse: {},
    recoverResponse: {},
    error: {},
  }),
  getters: employeeGetters,
  mutations: employeeMutations,
  actions: employeeActions,
}
