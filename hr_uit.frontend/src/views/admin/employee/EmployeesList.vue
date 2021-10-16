<template>
  <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-uppercase">
            Id
          </th>
          <th class="text-center text-uppercase">
            FullName
          </th>
          <th class="text-center text-uppercase">
            Date Of Birth
          </th>
          <th class="text-center text-uppercase">
            PhoneNumber
          </th>
          <th class="text-center text-uppercase">
            Identity Card
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in employees"
          :key="item.id"
        >
          <td class="text-center">
            {{ item.id }}
          </td>
          <td>{{ item.firstName + ' ' + item.lastName }}</td>
          <td class="text-center">
            {{ item.dateOfBirth }}
          </td>
          <td class="text-center">
            {{ item.phoneNumber }}
          </td>
          <td class="text-center">
            {{ item.identityCard }}
          </td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>

<script>
import EmployeeService from '@/services/employee-service'

const employeeService = new EmployeeService()

export default {
  data() {
    return {
      employees: [],
    }
  },
  created() {
    this.initialize()
  },
  methods: {
    async initialize() {
      this.employees = await employeeService.getEmployees()
    },
  },
}
</script>
