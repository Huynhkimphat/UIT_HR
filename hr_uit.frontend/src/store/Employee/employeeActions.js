import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async getEmployees(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload}` },
    }
    const result = await axios.get(`${API_URL}/employee/all`, config)
    context.commit('getEmployees', result.data)
  },
  async getEmployeeByCurrentId(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.get(`${API_URL}/employee/${payload.userId}`, config)
    context.commit('getEmployeeByCurrentId', result.data)
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
  async resetPassword(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.patch(
      `${API_URL}/employee/account/${payload.employeeId}/change`,
      payload.resetPassword,
      config,
    )
    context.commit('resetEmployeePassword', result.data)
  }
  ,
}
