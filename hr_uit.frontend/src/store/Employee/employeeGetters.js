export default {
  getEmployees(state) {
    return state.employees
  },
  createEmployee(state) {
    return state.createResponse
  },
  deleteEmployee(state) {
    return state.deleteResponse
  },
  recoverEmployee(state) {
    return state.recoverResponse
  },
  getEmployee(state) {
    return state.employee
  },
}
