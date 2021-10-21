import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async getEmployees(context) {
    const result = await axios.get(`${API_URL}/employee/all`)
    context.commit('getEmployees', result.data)
  },
  async createEmployee(context, payload) {
    const result = await axios.post(`${API_URL}/employee`, payload)
    context.commit('createEmployee', result.data)
  },
  async deleteEmployee(context, payload) {
    console.log(payload)
    const result = await axios.patch(`${API_URL}/employee/delete/${payload.employeeId}`)
    context.commit('deleteEmployee', result.data)
  },
  async recoverEmployee(context, payload) {
    const result = await axios.patch(`${API_URL}/employee/recover/${payload.employeeId}`)
    context.commit('recoverEmployee', result.data)
  },
}
