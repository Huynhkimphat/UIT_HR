export default {
  createAttendance(state, payload) {
    state.createResponse = payload
  },
  updateAttendance(state, payload) {
    state.createResponse = payload
  },
  addAttendanceToEmployee(state, payload) {
    state.createResponse = [payload]
  },
  resetState(state) {
    state.attendances = []
    state.attendance = {}
    state.createResponse = {}
    state.deleteResponse = {}
    state.recoverResponse = {}
    state.updateResponse = {}
    state.error = {}
  },
}
