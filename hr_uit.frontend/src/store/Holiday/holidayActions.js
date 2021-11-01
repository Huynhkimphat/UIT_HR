import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async getHolidays(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload}` },
    }
    const result = await axios.get(`${API_URL}/holiday/all`, config)
    context.commit('getHolidays', result.data)
  },
  async createHoliday(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.post(`${API_URL}/holiday`, payload.newHoliday, config)
    context.commit('createHoliday', result.data)
  },
}
