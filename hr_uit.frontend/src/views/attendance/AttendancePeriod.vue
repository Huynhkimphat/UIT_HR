<template>
  <v-card
    :height="`223px`"
    class="d-flex flex-column justify-space-between"
  >
    <v-card-actions class="primary pa-0">
      <v-btn
        color="primary"
        dark
        block
        large
      >
        WORKING TIME
      </v-btn>
    </v-card-actions>
    <div
      class="clock-inner"
    >
      <div class="hour">
        {{ hours }}
      </div>
      <div class="dots">
        :
      </div>
      <div class="min">
        {{ minutes }}
      </div>
      <div class="dots">
        :
      </div>
      <div class="secs">
        {{ seconds }}
      </div>
      <div class="mode"></div>
    </div>
  </v-card>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  // eslint-disable-next-line vue/require-prop-types
  props: {
    isCheckIn: Boolean,
  },
  data() {
    return {
      hours: 0,
      minutes: 0,
      seconds: 0,
      interval: null,
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
    ...mapGetters('attendanceStore', ['createAttendance', 'updateAttendance', 'getTimeCounting']),
  },
  watch: {
    createAttendance() {
      if (this.interval == null) {
        this.interval = setInterval(this.incrementTime, 1000)
      }
    },
    updateAttendance() {
      clearInterval(this.interval)
      this.interval = null
      this.seconds = 0
      this.minutes = 0
      this.hours = 0
    },
    seconds(value) {
      if (value === 59) {
        this.minutes += 1
        this.seconds = 0
      }
    },
    minutes(value) {
      if (value === 59 && this.seconds === 59) {
        this.minutes = 0
        this.hours += 1
      }
    },
  },
  mounted() {
    if (this.getEmployee.employeeAttendances.at(0).isProgressing) {
      const missingDate = new Date(this.getEmployee.employeeAttendances.at(0).fromDate)
      const curDate = new Date()
      const sum = (curDate.getHours() * 60 + curDate.getMinutes()) - (missingDate.getHours() * 60 + missingDate.getMinutes())
      console.log(sum)
      if (sum < 60) {
        this.minutes = sum
      } else {
        this.minutes = sum % 60
        this.hours = ((sum - (sum % 60)) / 60)
      }
      this.seconds = curDate.getSeconds()
      this.interval = setInterval(this.incrementTime, 1000)
    }
  },
  methods: {
    incrementTime() {
      // eslint-disable-next-line radix
      this.seconds = parseInt(this.seconds) + 1
    },
  },
}
</script>

<style scoped>
.hour, .min, .secs {
  font-size: 70px;
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
  height: 80%;
  background: #c48eff;
  color: darkblue;
}
.dots {
  font-size: 60px;
}
</style>
