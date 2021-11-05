<template>
  <v-expansion-panels focusable>
    <v-expansion-panel
      v-for="(holiday,i) in getHolidays"
      :key="i"
    >
      <v-expansion-panel-header>{{ holiday.nameOfHoliday }} ({{ holiday.dateOfHoliday | humanizeDate }})</v-expansion-panel-header>
      <v-expansion-panel-content>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
      </v-expansion-panel-content>
      <v-expansion-panel-content>
        <v-btn
          class="mb-2"
          color="primary"
          outlined
          type="reset"
        >
          Create New
        </v-btn>
        <v-btn
          class="mb-2"
          color="primary"
          outlined
          type="reset"
        >
          Update
        </v-btn>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data() {
    return {

    }
  },
  computed: {
    ...mapGetters('holidayStore', ['getHolidays', 'createHoliday']),
  },
  watch: {
    createHoliday() {
      this.initialize()
    },
  },
  created() {
    this.initialize()
  },
  methods: {
    async initialize() {
      await this.$store.dispatch('holidayStore/getHolidays', this.$store.state.token)
    },
  },
}
</script>

<style scoped>

</style>
