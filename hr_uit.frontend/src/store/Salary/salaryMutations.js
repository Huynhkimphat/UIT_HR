export default {
  getSalaryByYearMonth(state, payload) {
    state.salaries = payload
  },
  createNewSalary(state, payload) {
    state.createResponse = payload
  },
  addSalaryToEmployee(state, payload) {
    state.addResponse = payload
  },
}
