<template>
  <v-row>
    <v-col
      cols="12"
      md="6"
    >
      <attendance-info></attendance-info>
    </v-col>
    <v-col
      cols="12"
      md="6"
    >
      <attendance-status></attendance-status>
    </v-col>
  </v-row>
</template>

<script>
import AttendanceInfo from '@/views/attendance/AttendanceInfo.vue'
import AttendanceStatus from '@/views/attendance/AttendanceStatus.vue'

export default {
  components: {
    AttendanceInfo,
    AttendanceStatus,
  },
}
</script>

<style scoped>

</style>
