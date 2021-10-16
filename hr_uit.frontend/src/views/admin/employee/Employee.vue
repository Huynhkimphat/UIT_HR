<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <v-card-title>Basic</v-card-title>
        <EmployeesList></EmployeesList>
      </v-card>
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
