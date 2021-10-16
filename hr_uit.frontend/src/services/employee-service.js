import axios from 'axios'

// import { IServiceResponse } from '@/types/ServiceResponse'

export default class EmployeeService {
  constructor() {
    this.API_URL = process.env.VUE_APP_API_URL
  }

  async getEmployees() {
    console.log(this.API_URL)
    const result = await axios.get(`${this.API_URL}/employee/all`)

    return result.data
  }
}
