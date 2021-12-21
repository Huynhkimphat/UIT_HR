<template>
  <v-container
    class="white"
  >
    <v-row
      class="justify-center"
    >
      <v-col
        class="d-flex"
        cols="12"
        md="4"
      >
        <v-select
          v-model="monthInput"
          :items="months"
          item-text="month"
          items-value="value"
          label="Select month"
        >
        </v-select>
      </v-col>
      <v-col
        cols="12"
        md="4"
      >
        <v-select
          v-model="yearInput"
          :items="years"
          label="Select year"
        >
        </v-select>
      </v-col>
    </v-row>
    <v-row
      class="justify-center"
    >
      <v-btn
        color="primary"
        class="mb-2"
        @click="searchForSalary"
      >
        <span>
          Search
        </span>
      </v-btn>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data() {
    return {
      months: [
        { month: 'January', value: 1 },
        { month: 'February', value: 2 },
        { month: 'March', value: 3 },
        { month: 'April', value: 4 },
        { month: 'May', value: 5 },
        { month: 'June', value: 6 },
        { month: 'July', value: 7 },
        { month: 'August', value: 8 },
        { month: 'September', value: 9 },
        { month: 'October', value: 10 },
        { month: 'November', value: 11 },
        { month: 'December', value: 12 },
      ],
      years: [2021, 2022],
      monthInput: new Date().getMonth() + 1,
      yearInput: new Date().getFullYear(),
    }
  },
  computed: {
    ...mapGetters('salaryStore', ['getSalaries']),
  },
  mounted() {
    this.searchForSalary()
  },
  methods: {
    async searchForSalary() {
      await this.$store.dispatch('salaryStore/getSalaryByYearMonth', {
        token: this.$store.state.token,
        year: this.yearInput,
        month: this.monthInput,
      })
      this.$store.state.salaryStore.year = this.yearInput
      this.$store.state.salaryStore.month = this.monthInput
    },
  },
}
</script>

<style scoped>

</style>
