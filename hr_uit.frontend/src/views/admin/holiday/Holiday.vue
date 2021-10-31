<template>
  <v-row>
    <v-col cols="12">
      <v-col
        cols="12"
      >
        <HolidayNew></HolidayNew>
      </v-col>
      <v-card>
        <v-card-title>Holiday</v-card-title>
        <HolidayList></HolidayList>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import HolidayNew from './HolidayNew.vue'
import HolidayList from './HolidayList.vue'

export default {
  components: {
    HolidayNew,
    HolidayList,
  },
}
</script>

<style scoped>

</style>
