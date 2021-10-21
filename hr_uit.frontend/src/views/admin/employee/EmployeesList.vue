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
            <v-menu transition="fab-transition">
              <template v-slot:activator="{ on, attrs }">
                <v-btn
                  dark
                  color="primary"
                  v-bind="attrs"
                  v-on="on"
                >
                  See More
                </v-btn>
              </template>
              <v-list>
                <v-list-item>
                  <v-list-item-title>
                    Street {{ item.primaryAddress.addressLine }}
                  </v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>
                    Ward {{ item.primaryAddress.ward }}
                  </v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>
                    District {{ item.primaryAddress.district }}
                  </v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>
                    City : {{ item.primaryAddress.city }}
                  </v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>
                    Country: {{ item.primaryAddress.country }}
                  </v-list-item-title>
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
  data() {
    return {
      opened: [],
      dialog: false,
    }
  },
  computed: {
    // mapGetters(namespace, ['...'])
    ...mapGetters('employeeStore', ['getEmployees', 'createEmployee']),
  },
  watch: {
    createEmployee() {
      this.initialize()
    },
  },
  created() {
    this.initialize()
  },
  methods: {
    async initialize() {
      await this.$store.dispatch('employeeStore/getEmployees')
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
