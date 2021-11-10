<template>
  <v-simple-table dark>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-uppercase text--primary">
            ID
          </th>
          <th class="text-center text-uppercase text--primary">
            Date
          </th>
          <th class="text-center text-uppercase text--primary">
            Check In Time
          </th>
          <th class="text-center text-uppercase text--primary">
            Check Out Time
          </th>
          <th class="text-center text-uppercase text--primary">
            Period
          </th>
          <th class="text-center text-uppercase text--primary">
            Status
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in getEmployees.employeeAttendances"
          :key="item.id"
        >
          <td>{{ item.id }}</td>
          <td class="text-center">
            {{ item.createdOn }}
          </td>
          <td class="text-center">
            {{ item.fromDate }}
          </td>
          <td class="text-center">
            {{ item.toDate }}
          </td>
          <td class="text-center">
            {{ item.period }}
          </td>
          <td class="text-center">
            {{ item.isProgressing }}
          </td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('employeeStore', ['getEmployees']),
  },
}
</script>

<style scoped>

</style>
