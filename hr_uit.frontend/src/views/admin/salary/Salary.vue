<template>
  <v-row>
    <v-col
      cols="12"
    >
      <CreateSalary />
    </v-col>
    <v-col
      cols="12"
    >
      <v-card class="justify-center">
        <h1>Employee Salary List</h1>
        <EmployeeSalaryList />
      </v-card>
    </v-col>
  </v-row>
</template>

<script>

import EmployeeSalaryList from './SalaryList.vue'
import CreateSalary from './SalaryCreate.vue'

export default {
  components: {
    EmployeeSalaryList,
    CreateSalary,
  },
}
</script>

<style scoped>

</style>
