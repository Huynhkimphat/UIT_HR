import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async createNewAttendance(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.post(`${API_URL}/employee/attendance/checkin`, payload.attendance, config)
    context.commit('createAttendance', result.data)
  },
  async updateAttendance(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.patch(`${API_URL}/employee/attendance/checkout/${payload.attendanceId}`, payload.attendance, config)
    context.commit('updateAttendance', result.data)
  },
  async AddAttendanceToEmployee(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.patch(`${API_URL}/employee/attendance/${payload.employeeId}/add/${payload.attendanceId}`, {}, config)
    context.commit('addAttendanceToEmployee', result.data)
  },
}
