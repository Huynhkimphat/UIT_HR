import axios from 'axios'
import API_URL from '@/utils/API_URL'

export default {
  async getSalaryByYearMonth(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.get(`${API_URL}/salary/${payload.year}/${payload.month}`, config)
    context.commit('getSalaryByYearMonth', result.data)
  },
  async createSalary(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.post(`${API_URL}/salary`, payload.salary, config)
    context.commit('createNewSalary', result.data)
  },
  async addSalaryToEmployee(context, payload) {
    const config = {
      headers: { Authorization: `Bearer ${payload.token}` },
    }
    const result = await axios.patch(`${API_URL}/employee/salary/${payload.salaryId}/add/${payload.employeeId}`, {}, config)
    context.commit('addSalaryToEmployee', result.data)
  },
}
