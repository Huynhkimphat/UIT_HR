<template>
  <v-row>
    <v-col cols="12">
      <v-col
        cols="12"
      >
        <EmployeeCreateNew></EmployeeCreateNew>
      </v-col>
      <v-card>
        <v-card-title>Employees</v-card-title>
        <EmployeesList></EmployeesList>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import EmployeesList from './EmployeesList.vue'
import EmployeeCreateNew from './EmployeeCreateNew.vue'

export default {
  components: {
    EmployeeCreateNew,
    EmployeesList,
  },
}
</script>

<style scoped>

</style>
