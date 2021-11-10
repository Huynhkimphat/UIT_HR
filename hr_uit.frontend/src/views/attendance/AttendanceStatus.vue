<template>
  <v-card
    :height="`223px`"
    class="d-flex flex-column justify-space-between"
  >
    <v-card-title>
      Status : <span :class="checkIn ? 'green-text' : 'red-text'">
        {{ checkIn ? 'Working' : 'Missing' }}
      </span>
    </v-card-title>
    <v-card-text
      class="text--primary text-base"
    >
      Date :
      <span class="font-weight-bold">
        {{ currentDate.getDate() + '/' + (currentDate.getMonth()+1) + '/' + currentDate.getFullYear() }}
      </span>
    </v-card-text>
    <v-card-text
      v-model="currentDate"
      class="text--primary text-base"
    >
      Time counting : {{ currentDate.getSeconds() }}
    </v-card-text>
    <v-progress-linear
      buffer-value="90"
      stream
      color="#E53935"
    ></v-progress-linear>
    <v-card-actions class="primary pa-0">
      <v-btn
        :color="checkIn ? '#E53935' : '#00E676'"
        dark
        depressed
        block
        large
        @click="createAttendance(getEmployee.id, getNewAttendanceId)"
      >
        {{ checkIn ? 'Check Out': 'Check In' }}
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
import { mapGetters } from 'vuex'

export default {
  data() {
    return {
      checkIn: false,
      currentDate: new Date(),
      newAttendanceId: '',
      newAttendance: {
        fromDate: '',
        toDate: '',
        isProgressing: '',
        createdOn: Date.now,
        updatedOn: Date.now,
        isArchived: false,
      },
    }
  },
  methods: {
    ...mapGetters('employeeStore', ['getEmployee']),
    ...mapGetters('attendanceStore', ['createAttendance', 'getNewAttendanceId']),
    async createAttendance(empId, newAttId) {
      this.checkIn = !this.checkIn
      if (this.checkIn) {
        this.newAttendance.fromDate = Date.now()
        this.newAttendance.isProgressing = true
        console.log(this.newAttendance)
        await this.$store.dispatch('attendanceStore/createNewAttendance', this.newAttendance).then(
          console.log(this.newAttendanceId),
        )
        await this.$store.dispatch('attendanceStore/AddAttendanceToEmployeee', {
          employeeId: empId,
          attendanceId: newAttId,
        }).then(
          console.log(newAttId),
        )
      } else {
        this.newAttendance.toDate = Date.now()
        this.newAttendance.isProgressing = true
        await this.$store.dispatch('attendanceStore/updateAttendance', this.newAttendance)
      }
    },
  },
}
</script>

<style scoped>
.green-text {
  color: #00C853;
}
.red-text {
  color: #E53935;
}
</style>
