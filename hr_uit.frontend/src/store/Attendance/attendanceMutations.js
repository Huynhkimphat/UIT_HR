export default {
  createAttendance(state, payload) {
    state.createResponse = payload
  },
  updateAttendance(state, payload) {
    state.updateResponse = payload
  },
  addAttendanceToEmployee(state, payload) {
    state.addResponse = payload
  },
  updateMins(state, payload) {
    state.timeCounting.mins = payload
  },
  updateHrs(state, payload) {
    state.timeCounting.hrs = payload
  },
  resetState(state) {
    state.attendances = []
    state.attendance = {}
    state.createResponse = {}
    state.deleteResponse = {}
    state.recoverResponse = {}
    state.addResponse = {}
    state.updateResponse = {}
    state.error = {}
    state.timeCounting = { hrs: 0, mins: 0 }
  },
}
