<template>
  <v-row>
    <v-col cols="12">
      <v-col cols="12">
        <dayOffLetterStatus></dayOffLetterStatus>
      </v-col>
      <v-col cols="12">
        <dayOffLetterCreate></dayOffLetterCreate>
      </v-col>
      <v-card>
        <v-card-title>Day-Off Letters</v-card-title>
        <dayOffLetterList></dayOffLetterList>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import dayOffLetterStatus from './dayOffLetterStatus.vue'
import dayOffLetterList from './dayOffLetterList.vue'
import dayOffLetterCreate from './dayOffLetterCreate.vue'

export default {
  components: {
    dayOffLetterStatus,
    dayOffLetterList,
    dayOffLetterCreate,
  },
}
</script>

<style scoped>

</style>
