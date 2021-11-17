<template>
  <v-card
    :height="`223px`"
    class="d-flex flex-column justify-space-between"
  >
    <v-card-title>
      Status : <span :class="isCheckIn ? 'green-text' : 'red-text'">
        {{ isCheckIn ? 'Working' : 'Missing' }}
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
    <v-progress-linear
      buffer-value="90"
      stream
      color="#E53935"
    ></v-progress-linear>
    <v-card-actions class="primary pa-0">
      <v-btn
        :color="isCheckIn ? '#E53935' : '#00E676'"
        dark
        depressed
        block
        large
        @click="isCheckIn ? updateAttendance() : createNewAttendance(getEmployee.id)"
      >
        {{ isCheckIn ? 'Check Out': 'Check In' }}
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
import { mapGetters, mapMutations } from 'vuex'

export default {
  // eslint-disable-next-line vue/require-prop-types
  props: ['seconds', 'minutes', 'hours'],
  data() {
    return {
      isCheckIn: false,
      currentDate: new Date(),
      newAttendance: {
        fromDate: new Date(),
        toDate: new Date(),
        isProgressing: false,
        period: 0,
        isExisted: false,
        isArchived: false,
      },
    }
  },
  mounted() {
    if ((this.getEmployee.employeeAttendances.at(0).isProgressing === true || this.createAttendance.data.isProgressing)) {
      this.isCheckIn = true
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
    ...mapGetters('attendanceStore', ['createAttendance', 'getNewAttendanceId', 'getTimeCounting']),
  },
  methods: {
    ...mapMutations('attendanceStore', ['resetState']),
    async createNewAttendance(empId) {
      this.isCheckIn = true
      this.newAttendance.fromDate = new Date().toLocaleString()
      this.newAttendance.toDate = new Date().toLocaleString()
      this.newAttendance.isProgressing = true
      await this.$store.dispatch('attendanceStore/createNewAttendance',
        { attendance: this.newAttendance, token: this.$store.state.token })

      await this.$store.dispatch('attendanceStore/AddAttendanceToEmployee',
        {
          token: this.$store.state.token,
          attendanceId: this.$store.state.attendanceStore.createResponse.data.id,
          employeeId: empId,
        })
    },
    async updateAttendance() {
      this.isCheckIn = false
      this.newAttendance.toDate = new Date().toLocaleString()
      this.newAttendance.isProgressing = false
      this.newAttendance.period = this.getTimeCounting.hrs * 60 + this.getTimeCounting.mins
      await this.$store.dispatch('attendanceStore/updateAttendance',
        {
          attendance: this.newAttendance,
          token: this.$store.state.token,
          attendanceId: this.$store.state.attendanceStore.createResponse.data.id,
        }).then(this.resetState)
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
