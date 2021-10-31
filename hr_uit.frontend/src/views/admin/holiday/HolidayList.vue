<template>
  <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-uppercase text-center">
            Id
          </th>
          <th class="text-center text-uppercase">
            Name Of Holiday
          </th>
          <th class="text-center text-uppercase">
            Create On
          </th>
          <th class="text-center text-uppercase">
            Last Updated
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
export default {
}
</script>

<style scoped>

</style>
