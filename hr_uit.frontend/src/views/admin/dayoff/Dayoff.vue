<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <v-card-title>Employees Day Off Info</v-card-title>
        <DayOffList></DayOffList>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import DayOffList from './DayOffList.vue'

export default {
  components: {
    DayOffList,
  },
}
</script>

<style scoped>

</style>
