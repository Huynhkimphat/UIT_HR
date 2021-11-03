import moment from 'moment'

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
    state.employee.dateOfBirth = moment(String(state.employee.dateOfBirth)).format('YYYY-MM-DD')
    state.employee.createdOn = moment(String(state.employee.createdOn)).format('YYYY-MM-DD')

    return state.employee
  },
}
