<template>
  <v-simple-table dark>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-uppercase text--primary">
            ID
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
      <tbody
        v-for="item in getEmployee.employeeAttendances"
        :key="item.id"
      >
        <tr
          v-if="!item.isArchived"
        >
          <td>{{ item.id }}</td>
          <td class="text-center">
            {{ item.fromDate | getFullDateTime }}
          </td>
          <td
            v-if="!item.isProgressing"
            class="text-center"
          >
            {{ item.toDate | getFullDateTime }}
          </td>
          <td
            v-else
            class="text-center"
          ></td>
          <td class="text-center">
            {{ item.period }}
          </td>
          <td class="text-center">
            <span :class="item.isProgressing ? 'progressingText' : 'doneText'">
              {{ item.isProgressing ? 'Progressing' : 'Done' }}
            </span>
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
    ...mapGetters('employeeStore', ['getEmployee']),
    ...mapGetters('attendanceStore', ['createAttendance', 'updateAttendance', 'addAttendanceToEmployee']),
  },
  watch: {
    addAttendanceToEmployee() {
      this.initialize()
    },
    updateAttendance() {
      this.initialize()
    },
  },
  created() {
    this.initialize()
  },
  methods: {
    async initialize() {
      await this.$store.dispatch('employeeStore/getEmployeeByCurrentId', {
        token: this.$store.state.token,
        userId: this.$store.state.userId,
      })
    },
  },
}
</script>

<style scoped>
.progressingText {
  color: #00C853;
  text-align: center;
}
.doneText {
  color: #E53935;
  text-align: center;
}
</style>
