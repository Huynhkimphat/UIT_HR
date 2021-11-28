<template>
  <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-uppercase text--primary">
            ID
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
        v-for="item in getEmployee.primaryDayOffLetters"
        :key="item.id"
      >
        <tr>
          <td>{{ item.id }}</td>
          <td class="text-center">
            {{ item.fromDateTime | humanizeDate }}
          </td>
          <td class="text-center">
            {{ item.toDateTime | humanizeDate }}
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
                    <span class="acceptedText">Reason:</span><br>
                    {{ item.reason }}
                  </v-list-item-title>
                </v-list-item>
              </v-list>
            </v-menu>
          </td>
          <td
            v-if="item.isArchived === true"
            class="text-center"
          >
            <v-btn
              v-if="item.isApproved"
              class="ma-2"
              color="#2196F3"
              dark
            >
              <span>
                Accepted
              </span>
              <v-icon
                v-model="icon.accepted"
                dark
                right
              >
                {{ icon.accepted }}
              </v-icon>
            </v-btn>
            <v-btn
              v-else
              class="ma-2"
              color="#FB8C00"
              dark
            >
              <span>
                Pending
              </span>
              <v-icon
                v-model="icon.accepted"
                dark
                right
              >
                {{ icon.accepted }}
              </v-icon>
            </v-btn>
          </td>
          <td
            v-else
            class="text-center"
          >
            <v-btn
              class="ma-2"
              color="#D50000"
              dark
            >
              Decline
              <v-icon
                v-model="icon"
                dark
                right
              >
                {{ icon.declined }}
              </v-icon>
            </v-btn>
          </td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>

<script>
import { mapGetters } from 'vuex'
import { mdiAccessPoint, mdiCancel, mdiCheckboxMarkedCircle } from '@mdi/js'

export default {
  data() {
    return {
      icon: {
        accepted: mdiCheckboxMarkedCircle,
        pending: mdiAccessPoint,
        declined: mdiCancel,
      },
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
    ...mapGetters('dayOffLetterStore', ['addDayOffLetterToEmployee']),
  },
  watch: {
    addDayOffLetterToEmployee() {
      this.initialize()
    },
  },
  mounted() {
    console.log(this.getEmployee.primaryDayOffLetters)
    this.initialize()
  },
  methods: {
    async initialize() {
      await this.$store.dispatch('employeeStore/getEmployeeByCurrentId', {
        token: this.$store.state.token,
        userId: this.$store.state.userId,
      })
    },
  },
}
</script>

<style scoped>
.acceptedText {
  color: red;
  font-weight: bold;
}
.pendingText {
  color: #00C853;
  font-weight: bold;
}
.declinedText {
  color: darkblue;
  font-weight: bold;
}
</style>
