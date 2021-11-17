<template>
  <div>
    <!--Employee Information and Status-->
    <v-row>
      <v-col
        md="5"
        cols="12"
      >
        <attendance-info></attendance-info>
      </v-col>
      <v-col
        md="3"
        cols="12"
      >
        <attendance-status></attendance-status>
      </v-col>
      <!--Attendance Period-->
      <v-col
        md="4"
        cols="12"
      >
        <attendance-period></attendance-period>
      </v-col>
    </v-row>
    <!--Attendance List-->
    <v-row>
      <v-col cols="12">
        <v-card>
          <v-card-title>Attendance Infomation</v-card-title>
          <attendance-table></attendance-table>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import AttendanceInfo from '@/views/attendance/AttendanceInfo.vue'
import AttendanceStatus from '@/views/attendance/AttendanceStatus.vue'
import AttendanceTable from '@/views/attendance/AttendanceTable.vue'
import AttendancePeriod from '@/views/attendance/AttendancePeriod.vue'

export default {
  components: {
    AttendanceInfo,
    AttendanceStatus,
    AttendanceTable,
    AttendancePeriod,
  },
}
</script>

<style scoped>

</style>
