<template>
  <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-uppercase text-center">
            Id
          </th>
          <th class="text-center text-uppercase">
            FullName
          </th>
          <th class="text-center text-uppercase">
            Email
          </th>
          <th class="text-center text-uppercase">
            DayOff
          </th>
          <th class="text-center text-uppercase">
            PhoneNumber
          </th>
          <th class="text-center text-uppercase">
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in getEmployees"
          :key="item.id"
        >
          <td class="text-center">
            {{ item.id }}
          </td>
          <td class="text-center">
            {{ item.firstName + ' ' + item.lastName }}
          </td>
          <td class="text-center">
            {{ item.primaryAccount.email }}
          </td>
          <td class="text-center">
            {{ item.primaryDayOff.dayOffAmount }}
          </td>
          <td class="text-center">
            {{ item.phoneNumber }}
          </td>
          <td class="text-center">
            <v-btn
              class="ma-2 resetBtn"
              @click="resetDayOff(item.primaryDayOff.id)"
            >
              Reset DayOff
            </v-btn>
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
    // mapGetters(namespace, ['...'])
    ...mapGetters('employeeStore', ['getEmployees']),
  },
  created() {
    this.initialize()
  },
  methods: {
    async initialize() {
      await this.$store.dispatch('employeeStore/getEmployees', this.$store.state.token)
    },
    async resetDayOff(id) {
      console.log(id)
    },
  },
}
</script>

<style scoped>

</style>
