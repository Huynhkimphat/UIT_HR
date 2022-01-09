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
        <h2 class="ml-4">
          Employee Salary List
        </h2>
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
