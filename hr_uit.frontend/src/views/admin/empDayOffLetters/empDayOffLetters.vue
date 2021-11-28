<template>
  <v-row justify="center">
    <v-col cols="10">
      <v-card>
        <v-card-title>Employee Day-Off Letters</v-card-title>
        <empDayOffLetterList></empDayOffLetterList>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import empDayOffLetterList from './empDayOffLetterList.vue'

export default {
  components: {
    empDayOffLetterList,
  },
}
</script>

<style scoped>

</style>
