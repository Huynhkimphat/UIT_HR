<template>
  <v-card>
    <v-card-title class="align-start">
      <span class="font-weight-semibold">What do you want to do ? </span>
      <v-spacer></v-spacer>
    </v-card-title>
    <v-card-subtitle class="mb-8 mt-n5">
      <span class="font-weight-semibold text--primary me-1">Total 48.5% Growth</span>
      <span>😎 this month</span>
    </v-card-subtitle>

    <v-card-text>
      <v-btn
        color="primary"
        class="mr-2"
        @click="$router.push('attendance')"
      >
        <span
          class="mr-2"
        >
          CheckIn / CheckOut
        </span>
      </v-btn>
      <v-btn
        color="primary"
        class="mr-2"
        @click="$router.push('dayoffletter')"
      >
        <span
          class="mr-2"
        >
          Create DayOff Letter
        </span>
      </v-btn>
      <v-btn
        v-if="$store.getters.getRole==='Admin'"
        color="primary"
        class="mr-2"
        @click="$router.push('admin/employee')"
      >
        <span
          class="mr-2"
        >
          Manage Employee
        </span>
      </v-btn>
      <v-btn
        v-if="$store.getters.getRole==='Admin'"
        color="primary"
        class="mr-2"
        @click="$router.push('admin/salary')"
      >
        <span
          class="mr-2"
        >
          Send Salary
        </span>
      </v-btn>
      <v-btn
        v-if="$store.getters.getRole==='Admin'"
        color="primary"
        class="mr-2"
        @click="$router.push('admin/empDayOffLetters')"
      >
        <span
          class="mr-2"
        >
          Check Employee's Day Off Letter
        </span>
      </v-btn>
      <v-btn
        v-if="$store.getters.getRole==='Admin'"
        color="primary"
        class="mr-2"
        @click="$router.push('admin/holiday')"
      >
        <span
          class="mr-2"
        >
          Create Holiday
        </span>
      </v-btn>
    </v-card-text>
  </v-card>
</template>

<script>
// eslint-disable-next-line object-curly-newline
import { mdiAccountOutline, mdiCurrencyUsd, mdiTrendingUp, mdiDotsVertical, mdiLabelOutline } from '@mdi/js'

export default {
  setup() {
    const statisticsData = [
      {
        title: 'Sales',
        total: '245k',
      },
      {
        title: 'Customers',
        total: '12.5k',
      },
      {
        title: 'Product',
        total: '1.54k',
      },
      {
        title: 'Revenue',
        total: '$88k',
      },
    ]

    const resolveStatisticsIconVariation = data => {
      if (data === 'Sales') return { icon: mdiTrendingUp, color: 'primary' }
      if (data === 'Customers') return { icon: mdiAccountOutline, color: 'success' }
      if (data === 'Product') return { icon: mdiLabelOutline, color: 'warning' }
      if (data === 'Revenue') return { icon: mdiCurrencyUsd, color: 'info' }

      return { icon: mdiAccountOutline, color: 'success' }
    }

    return {
      statisticsData,
      resolveStatisticsIconVariation,

      // icons
      icons: {
        mdiDotsVertical,
        mdiTrendingUp,
        mdiAccountOutline,
        mdiLabelOutline,
        mdiCurrencyUsd,
      },
    }
  },
}
</script>
