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
    resetResponse: {},
    error: {},
  }),
  getters: employeeGetters,
  mutations: employeeMutations,
  actions: employeeActions,
}
