import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async createNewDayOffLetter(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.post(`${API_URL}/employee/day-off-letter`, payload.dayOffLetter, config)
    context.commit('createDayOffLetter', result.data)
  },
  async addDayOffLetterToEmployee(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.patch(`${API_URL}/day-off-letter/${payload.dayOffLetterId}/add/employee/${payload.employeeId}`, {}, config)
    context.commit('addDayOffLetterToEmployee', result.data)
  },
  async declineLetter(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.patch(`${API_URL}/employee/day-off-letter/recover/${payload.dayOffLetterId}`, {}, config)
    context.commit('declineDayOffLetter', result.data)
  },
  async approveLetter(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.patch(`${API_URL}/employee/day-off-letter/${payload.dayOffLetterId}/approved`, {}, config)
    context.commit('approveDayOffLetter', result.data)
  },
}
