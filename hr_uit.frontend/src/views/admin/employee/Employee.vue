<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <v-card-title>Employees</v-card-title>
        <EmployeesList></EmployeesList>
      </v-card>
      <v-col
        offset-md="0"
        cols="3"
      >
        <v-btn color="primary">
          New Employee
        </v-btn>
      </v-col>
    </v-col>
  </v-row>
</template>

<script>
// eslint-disable-next-line import/extensions
import EmployeesList from '@/views/admin/employee/EmployeesList'

export default {
  components: {
    EmployeesList,
  },
  setup() {
    return {}
  },
}
</script>

<style scoped>

</style>
