<template>
  <v-row>
    <v-col cols="12">
      <v-col
        cols="12"
      >
        <CreateSalary/>
      </v-col>
      <v-card>
        <v-card-title>Salary</v-card-title>
        <EmployeeSalaryList/>
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
    CreateSalary
  },
}
</script>

<style scoped>

</style>
