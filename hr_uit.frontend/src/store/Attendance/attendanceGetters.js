export default {
  getAttendances: state => state.attendances,
  createAttendance: state => state.createResponse,
  getAttendance: state => state.attendance,
  updateAttendance: state => state.updateResponse,
  getNewAttendanceId(state) {
    return state.createResponse.data.id
  },
  addAttendanceToEmployee: state => state.addResponse,
  getTimeCounting(state) {
    return state.timeCounting
  },
}
