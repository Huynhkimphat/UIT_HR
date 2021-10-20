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
            Status
          </th>
          <th class="text-center text-uppercase">
            PhoneNumber
          </th>
          <th class="text-center text-uppercase">
            Identity Card
          </th>
          <th class="text-center text-uppercase">
            More Info
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="item in getEmployees"
          :key="item.id"
          @click="toggle(item.id)"
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
            <v-chip
              class="ml-0 mr-2 white--text success"
              small
            >
              Working
            </v-chip>
          </td>
          <td class="text-center">
            {{ item.phoneNumber }}
          </td>
          <td class="text-center">
            {{ item.identityCard }}
          </td>
          <td class="text-center">
            <v-dialog
              v-model="dialog"
              width="1000"
            >
              <template v-slot:activator="{ on, attrs }">
                <v-btn
                  dark
                  v-bind="attrs"
                  v-on="on"
                >
                  See More
                </v-btn>
              </template>

              <v-card>
                <v-card-title class="text-h5">
                  {{ item.firstName + ' ' + item.lastName }}
                </v-card-title>
                <v-card-text>
                  Address: {{ item.primaryAddress.addressLine }}
                  Ward: {{ item.primaryAddress.ward }}
                  District: {{ item.primaryAddress.district }}
                  City: {{ item.primaryAddress.city }}
                  Country: {{ item.primaryAddress.country }}
                </v-card-text>
                <v-card-text>
                  Join On: {{ item.CreatedOn | humanizeDate }}
                </v-card-text>
                <v-card-text>
                  Birthday: {{ item.dateOfBirth | humanizeDate }}
                </v-card-text>
                <v-divider></v-divider>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn
                    color="primary"
                    text
                    @click="dialog = false"
                  >
                    I accept
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
          </td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data() {
    return {
      opened: [],
      dialog: false,
    }
  },
  computed: {
    ...mapGetters(['getEmployees']),
  },
  created() {
    this.initialize()
  },
  methods: {
    async initialize() {
      await this.$store.dispatch('getEmployees')
    },
    toggle(id) {
      const index = this.opened.indexOf(id)
      if (index > -1) {
        this.opened.splice(index, 1)
      } else {
        this.opened.push(id)
      }
    },
  },
}
</script>

<style lang="scss">

$color-pack: false
import '../../../../styles/styles.scss'

</style>
