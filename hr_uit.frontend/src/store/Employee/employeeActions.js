import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async getEmployees(context) {
    const result = await axios.get(`${API_URL}/employee/all`)
    context.commit('getEmployees', result.data)
  },
}
