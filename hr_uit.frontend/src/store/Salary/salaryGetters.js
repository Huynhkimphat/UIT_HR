export default {
  getSalaries(state) {
    return state.salaries
  },
  getNewSalary(state) {
    return state.createResponse
  },
  getIsFetchingData(state) {
    return state.isFetchingData
  },
  addSalaryToEmployee(state) {
    return state.addResponse
  },
}
