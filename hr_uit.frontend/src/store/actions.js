import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async login(context, payload) {
    const result = await axios.post(`${API_URL}/login/`, payload)

    return context.commit('login', result.data)
  },

  async logout(context) {
    context.commit('logout')
    context.commit('employeeStore/resetState')
  },

}
