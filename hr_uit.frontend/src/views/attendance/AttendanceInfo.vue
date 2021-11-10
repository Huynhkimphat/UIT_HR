<template>
  <v-card class="d-flex justify-space-between maxhg-250">
    <!-- Avatar -->
    <div class="col-6">
      <v-img
        class="bor-rad "
        :width="`226px`"
        :src="require('@/assets/images/avatars/1.png')"
      ></v-img>
    </div>
    <!-- Info -->
    <div class="col-6 d-flex flex-column justify-center">
      <v-card-text class="text--primary text-base">
        <span>Name : </span>
        <span class="font-weight-bold">{{ getEmployee.firstName + ' ' + getEmployee.lastName }}</span>
      </v-card-text>
      <v-card-text class="text--primary text-base">
        <span>Email :
        </span> <span class="font-weight-bold">{{ getEmployee.primaryAccount.email }}</span>
      </v-card-text>
      <v-card-text class="text--primary text-base">
        <span>Role : </span>
        <span class="font-weight-bold">{{ getRole }}</span>
      </v-card-text>
    </div>
  </v-card>
</template>

<script>
import { mapGetters } from 'vuex'
import {
  mdiCartPlus,
  mdiShareVariantOutline,
} from '@mdi/js'

export default {
  data() {
    return {
      // icons
      icons: {
        mdiCartPlus,
        mdiShareVariantOutline,
      },
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
    ...mapGetters(['getRole']),
  },
}
</script>

<style lang="scss" scoped>
.bor-rad{
  border-radius:50%;
}
.maxhg-250{
  max-height: 250px;
}
</style>
