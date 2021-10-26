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
          <th class="text-center text-uppercase">
          </th>
          <th class="text-center text-uppercase">
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
                    Date Of Birth : {{ item.dateOfBirth | humanizeDate }}
                  </v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>
                    Join On : {{ item.createdOn | humanizeDate }}
                  </v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>
                    Street : {{ item.primaryAddress.addressLine }}
                  </v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>
                    Ward : {{ item.primaryAddress.ward }}
                  </v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>
                    District : {{ item.primaryAddress.district }}
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
          <td class="text-center">
            <v-btn
              class="ma-2"
              :class="item.isArchived?'recoverBtn':'deleteBtn'"
              @click="item.isArchived?recoverEmployeeWithGivenId(item.id):deleteEmployeeWithGivenId(item.id)"
            >
              {{ item.isArchived ? 'Recover' : 'Delete' }}
              <v-icon
                right
              >
                {{ item.isArchived? restoreIcon.icon: deleteIcon.icon }}
              </v-icon>
            </v-btn>
          </td>
          <td class="text-center">
            <v-btn
              class="ma-2 resetBtn"
              @click="resetEmployeeWithGivenId(item.id)"
            >
              Reset Password
              <v-icon
                right
              >
                {{ item.isArchived? restoreIcon.icon: deleteIcon.icon }}
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
import { mdiDelete, mdiRestore } from '@mdi/js'
import bcrypt from 'bcryptjs'

export default {
  data() {
    return {
      opened: [],
      dialog: false,
      deleteIcon: { icon: mdiDelete, name: 'mdiDelete' },
      restoreIcon: { icon: mdiRestore, name: 'mdiRestore' },
    }
  },
  computed: {
    // mapGetters(namespace, ['...'])
    ...mapGetters('employeeStore', ['getEmployees', 'createEmployee', 'deleteEmployee', 'recoverEmployee']),
  },
  watch: {
    createEmployee() {
      this.initialize()
    },
    deleteEmployee() {
      this.initialize()
    },
    recoverEmployee() {
      this.initialize()
    },
  },
  created() {
    this.initialize()
  },
  methods: {
    async initialize() {
      await this.$store.dispatch('employeeStore/getEmployees', this.$store.state.token)
    },
    toggle(id) {
      const index = this.opened.indexOf(id)
      if (index > -1) {
        this.opened.splice(index, 1)
      } else {
        this.opened.push(id)
      }
    },
    async recoverEmployeeWithGivenId(id) {
      console.log(id)
      await this.$store.dispatch('employeeStore/recoverEmployee', { employeeId: id })
    },
    async deleteEmployeeWithGivenId(id) {
      await this.$store.dispatch('employeeStore/deleteEmployee', { employeeId: id })
    },
    async resetEmployeeWithGivenId(id) {
      const salt = bcrypt.genSaltSync(10)
      const hashPassword = bcrypt.hashSync('kimphat2001', salt)
      await this.$store.dispatch('employeeStore/resetPassword', {
        employeeId: id,
        resetPassword: {
          username: '',
          password: hashPassword,
        },
        token: this.$store.state.token,
      })
    },
  },
}
</script>

<style lang="scss" scoped>
$color-pack: false
import '../../../../styles/styles.scss';

.deleteBtn{
  min-width:150px !important;
  color:red !important;
  //border:1px solid var(--v-primary-base);
}

.recoverBtn{
  min-width:150px !important;
  color:darkorange !important;
  //border:1px solid var(--v-primary-base);
}
</style>
