export default {
  getEmployees(state, payload) {
    state.employees = payload
  },
  createEmployee(state, payload) {
    state.response = payload
  },
}
