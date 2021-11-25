<template>
  <v-card
    color="transparent"
    max-height="150px"
    class="d-flex justify-center"
  >
    <div class="col-6">
      <v-card-actions class="ma-0 pa-0">
        <v-btn
          color="#181D31"
          block
          dark
          large
        >
          REMAINING DAY-OFF
        </v-btn>
      </v-card-actions>
      <div
        class="clock-inner"
      >
        <div class="day">
          {{ days }}
        </div>
        <div class="day-text">
          Day(s)
        </div>
        <div class="mode"></div>
      </div>
    </div>
  </v-card>
</template>

<script>

import { mapGetters } from 'vuex'

export default {
  components: {
  },
  data() {
    return {
      days: 0,
      interval: null,
      fromDate: '',
      toDate: '',
      dateNow: new Date(),
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
  },
  mounted() {
    console.log()
  },
  method: {
    countDay() {
    },
  },
}
</script>

<style scoped>

.day {
  font-size: 6em;
}
.day-text {
  font-size: 3em;
  font-style: italic;
}
p {
  font-family: 'Lucida Sans', sans-serif;
  font-size: 20px;
  font-weight: bold;
}
.clock-inner {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 75%;
  background: #94B3FD;
  color: darkblue;
}
</style>
