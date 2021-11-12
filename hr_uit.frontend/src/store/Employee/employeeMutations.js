export default {
  getEmployees(state, payload) {
    state.employees = payload
  },
  getEmployeeByCurrentId(state, payload) {
    state.employee = payload
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
  updateEmployee(state, payload) {
    state.updateEmployee = payload
  },
}
