import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async login(context, payload) {
    const result = await axios.post(`${API_URL}/login/`, payload)
    if (!result.data.isSuccess) {
      return context.commit('loginFailed')
    }

    return context.commit('loginSucceed', result.data)
  },

  async logout(context) {
    context.commit('logout')
    context.commit('employeeStore/resetState')
    context.commit('holidayStore/resetState')
    context.commit('attendanceStore/resetState')
  },

}
