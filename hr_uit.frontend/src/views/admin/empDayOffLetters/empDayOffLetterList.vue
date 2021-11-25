<template>
  <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-center text-uppercase text--primary">
            ID
          </th>
          <th class="text-center text-uppercase text--primary">
            Employee Id
          </th>
          <th class="text-center text-uppercase text--primary">
            From Date
          </th>
          <th class="text-center text-uppercase text--primary">
            To Date
          </th>
          <th class="text-center text-uppercase text--primary">
            Reason
          </th>
          <th class="text-center text-uppercase text--primary">
            Status
          </th>
        </tr>
      </thead>
      <tbody
        v-for="item in getEmployees"
        :key="item.id"
      >
        <tr
          v-for="i in getDayOffLetters(item.primaryDayOffLetters)"
          :key="i.id"
        >
          <td class="text-center">
            {{ i.id }}
          </td>
          <td class="text-center">
            {{ item.id }}
          </td>
          <td class="text-center">
            {{ i.fromDateTime | humanizeDate }}
          </td>
          <td class="text-center">
            {{ i.toDateTime | humanizeDate }}
          </td>
          <td class="text-center">
            <v-menu transition="fab-transition">
              <template v-slot:activator="{ on, attrs }">
                <v-btn
                  dark
                  color="primary"
                  v-bind="attrs"
                  v-on="on"
                >
                  Details
                </v-btn>
              </template>
              <v-list>
                <v-list-item>
                  <v-list-item-title>
                    <span class="no-btn">Reason:</span><br>
                    {{ i.reason }}
                  </v-list-item-title>
                </v-list-item>
              </v-list>
            </v-menu>
          </td>
          <td
            class="text-center"
          >
            <v-menu
              transition="fab-transition"
              offset-x
              top
            >
              <template v-slot:activator="{ on, attrs }">
                <v-btn
                  dark
                  color="primary"
                  v-bind="attrs"
                  v-on="on"
                >
                  Approve
                </v-btn>
              </template>
              <v-list color="transparent">
                <v-list-item class="mb-2">
                  <v-btn
                    dark
                    color="success"
                    @click="approveLetter(i.id)"
                  >
                    Yes
                  </v-btn>
                </v-list-item>
                <v-list-item>
                  <v-btn
                    dark
                    color="error"
                    @click="declineLetter(i.id)"
                  >
                    No
                  </v-btn>
                </v-list-item>
              </v-list>
            </v-menu>
          </td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('dayOffLetterStore', ['approveDayOffLetter', 'declineDayOffLetter']),
    ...mapGetters('employeeStore', ['getEmployees']),
  },
  watch: {
    approveDayOffLetter() {
      this.initialize()
      console.log('success')
    },
    declineDayOffLetter() {
      this.initialize()
      console.log('success')
    },
  },
  mounted() {
    this.initialize()
    console.log(this.getEmployees)
  },
  methods: {
    getDayOffLetters(list) {
      return list.filter(i => i.isApproved === false && i.isArchived === true)
    },
    async initialize() {
      await this.$store.dispatch('employeeStore/getEmployees', this.$store.state.token)
    },
    async declineLetter(id) {
      await this.$store.dispatch('dayOffLetterStore/declineLetter', {
        token: this.$store.state.token,
        dayOffLetterId: id,
      })
    },
    async approveLetter(id) {
      await this.$store.dispatch('dayOffLetterStore/approveLetter', {
        token: this.$store.state.token,
        dayOffLetterId: id,
      })
    },
  },
}
</script>

<style scoped>
.yes-btn {
  color: #00C853;
}
.no-btn {
  color: red;
}
</style>
