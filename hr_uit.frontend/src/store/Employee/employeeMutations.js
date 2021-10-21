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
}
