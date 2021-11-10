import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async createNewAttendance(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload}` },
    }
    const result = await axios.post(`${API_URL}/employee/attendance/checkin`, payload.newAttendance, config)
    context.commit('createAttendance', result.data)
  },
  async updateAttendance(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload}` },
    }
    const result = await axios.put(`${API_URL}/employee/attendance/checkout`, payload.newAttendance, config)
    context.commit('updateAttendance', result.data)
  },
  async AddAttendanceToEmployeee(context, payload) {
    const config = {
      header: { Authorization: `Bearer ${payload}` },
    }
    const result = await axios.patch(`${API_URL}/employee/attendance/${payload.employeeId}/add/${payload.attendanceId}`, config)
    context.commit('addAttendanceToEmployee', result.data)
  },
}
