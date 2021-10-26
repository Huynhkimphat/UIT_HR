export default {
  getEmployees(state, payload) {
    state.employees = payload
  },
  createEmployee(state, payload) {
    state.createResponse = payload
  },
  deleteEmployee(state, payload) {
    state.deleteResponse = payload
  },
  recoverEmployee(state, payload) {
    state.recoverResponse = payload
  },
  resetEmployeePassword(state, payload) {
    state.resetResponse = payload
  },
  resetState(state) {
    state.employees = []
    state.createResponse = {}
    state.deleteResponse = {}
    state.recoverResponse = {}
  },
}
