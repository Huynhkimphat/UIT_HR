export default {
  getAttendances: state => state.attendances,
  createAttendance: state => state.createResponse,
  getAttendance: state => state.attendance,
  updateAttendance: state => state.updateResponse,
  getNewAttendanceId: state => state.createResponse.id,
}
