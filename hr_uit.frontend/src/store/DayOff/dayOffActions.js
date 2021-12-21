import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async updateDayOff(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.put(`${API_URL}/employee/day-off/update/${payload.dayOffId}`, payload.newDayOff, config)
    context.commit('updateDayOff', result.data)
  },
  async resetDayOff(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }

    console.log(payload.dayOffId)

    const result = await axios.put(`${API_URL}/employee/day-off/update/${payload.dayOffId.id}`, payload.dayOffId, config)
    context.commit('updateDayOff', result.data)
  },
}
