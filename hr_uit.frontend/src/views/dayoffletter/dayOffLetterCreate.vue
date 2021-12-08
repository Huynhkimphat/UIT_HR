<template>
  <v-row>
    <v-col
      class="d-flex justify-center"
      cols="12"
    >
      <v-btn
        color="primary"
        :disabled="!createEnable"
        @click="toggleCreateDayOffLetterForm()"
      >
        <v-icon
          v-model="icon"
          class="mr-2"
          size="30"
        >
          {{ icon }}
        </v-icon>
        <span
          class="mr-2"
        >
          Create new day-off letter
        </span>
      </v-btn>
    </v-col>
    <v-expand-transition>
      <v-col v-show="isCreateFormShow">
        <v-tabs v-model="tab">
          <v-tab
            href="#fromDate"
            @click="currentTab=1"
          >
            From Date
          </v-tab>
          <v-tab
            href="#toDate"
            :disabled="currentTab===1"
            @click="currentTab=2"
          >
            To Date
          </v-tab>
          <v-tab
            href="#reason"
            :disabled="currentTab!==3"
            @click="currentTab=3"
          >
            Reason
          </v-tab>
        </v-tabs>
        <v-tabs-items
          v-model="tab"
          class="full-width"
        >
          <v-tab-item value="fromDate">
            <v-form
              ref="form"
              v-model="valid"
            >
              <v-container>
                <v-row
                  class="d-flex justify-center"
                >
                  <v-col
                    cols="12"
                    md="4"
                  >
                    <v-menu
                      v-model="fromDateMenu"
                      :close-on-content-click="false"
                      :nudge-right="40"
                      transition="scale-transition"
                      offset-y
                      min-width="auto"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="newDayOffLetter.fromDateTime"
                          label="From Date"
                          :rules="fromDateRules"
                          readonly
                          v-on="on"
                        ></v-text-field>
                      </template>
                      <v-date-picker
                        v-model="newDayOffLetter.fromDateTime"
                        outlined
                        dense
                        :min="minDate"
                        @input="fromDateChanged"
                      ></v-date-picker>
                    </v-menu>
                  </v-col>
                </v-row>
              </v-container>
            </v-form>
          </v-tab-item>
          <v-tab-item value="toDate">
            <v-form
              ref="form2"
              v-model="valid"
            >
              <v-container>
                <v-row class="d-flex justify-center">
                  <v-col
                    cols="12"
                    md="4"
                  >
                    <v-menu
                      v-model="toDateMenu"
                      :close-on-content-click="false"
                      :nudge-right="40"
                      transition="scale-transition"
                      offset-y
                      min-width="auto"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="newDayOffLetter.toDateTime"
                          label="To Date"
                          readonly
                          :rules="toDateRules"
                          v-on="on"
                        ></v-text-field>
                      </template>
                      <v-date-picker
                        v-model="newDayOffLetter.toDateTime"
                        :disabled="!newDayOffLetter.fromDateTime"
                        outlined
                        dense
                        :min="minToDate"
                        @input="toDateMenu = false"
                      ></v-date-picker>
                    </v-menu>
                  </v-col>
                </v-row>
              </v-container>
            </v-form>
          </v-tab-item>
          <v-tab-item value="reason">
            <v-form
              ref="form3"
              v-model="valid"
            >
              <v-container>
                <v-row class="d-flex justify-center">
                  <v-col
                    cols="12"
                    md="6"
                  >
                    <v-textarea
                      v-model="newDayOffLetter.reason"
                      :rule="reasonRules"
                      :counter="100"
                      label="Reason"
                      required
                    ></v-textarea>
                  </v-col>
                </v-row>
              </v-container>
            </v-form>
          </v-tab-item>
        </v-tabs-items>
        <v-col
          offset-md="4"
          cols="5"
        >
          <v-btn
            color="primary"
            class="mx-2"
            :disabled="currentTab===1"
            @click="goToPreviousTab"
          >
            Back
          </v-btn>
          <v-btn
            color="primary"
            type="reset"
            outlined
            class="mx-2"
            @click="resetInfo"
          >
            Reset
          </v-btn>
          <v-btn
            color="primary"
            class="mx-2"
            :disabled="currentTab===3"
            @click="goToNextTab"
          >
            Next
          </v-btn>
        </v-col>
        <v-col
          offset-md="5"
          cols="2"
        >
          <v-btn
            color="primary"
            :disabled="currentTab!==3"
            @click="submitInfo"
          >
            Submit
          </v-btn>
        </v-col>
      </v-col>
    </v-expand-transition>
  </v-row>
</template>

<script>
import { mdiPlusCircleOutline } from '@mdi/js'
import { mapGetters, mapMutations } from 'vuex'

export default {
  data() {
    return {
      minDate: new Date().toISOString().slice(0, 10),
      minToDate: new Date(),
      isCreateFormShow: false,
      icon: mdiPlusCircleOutline,
      tab: null,
      currentTab: 1,
      valid: false,
      fromDateMenu: false,
      toDateMenu: false,
      createEnable: true,
      newDayOff: {
        dayOffAmount: '',
      },
      newDayOffLetter: {
        fromDateTime: '',
        toDateTime: '',
        reason: '',
        isExisted: false,
        isArchived: false,
        isApproved: false,
        dayOffCounting: 0,
        createdOn: '',
        updatedOn: '',
      },
      fromDateRules: [
        v => !!v || 'Date is required',
      ],
      toDateRules: [
        v => !!v || 'Date is required',
      ],
      reasonRules: [
        v => !!v || 'Reason is required',
        v => v.length <= 100 || 'Reason must be less than 100 characters',
      ],
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
    ...mapGetters('dayOffLetterStore', ['getCreateEnable']),
    ...mapMutations('dayOffLetterStore', ['unableCreate']),
  },
  watch: {
    currentTab(val) {
      if (val === 1) {
        this.tab = 'fromDate'
      } else if (val === 2) {
        this.tab = 'toDate'
      } else {
        this.tab = 'reason'
      }
    },
  },
  mounted() {
    this.newDayOff.dayOffAmount = this.getEmployee.primaryDayOff.dayOffAmount
    if (this.newDayOff.dayOffAmount === 0) {
      this.createEnable = false
    }
  },
  methods: {
    fromDateChanged() {
      this.fromDateMenu = false
      this.minToDate = new Date(this.newDayOffLetter.fromDateTime)
      this.minToDate = this.minToDate.setDate(this.minToDate.getDate() + 1)
      this.minToDate = new Date(this.minToDate).toISOString().slice(0, 10)
    },
    toggleCreateDayOffLetterForm() {
      this.isCreateFormShow = !this.isCreateFormShow
    },
    goToPreviousTab() {
      this.currentTab -= 1
    },
    resetInfo() {
      this.currentTab = 1
      this.newDayOffLetter.fromDateTime = ''
      this.newDayOffLetter.toDateTime = ''
      this.newDayOffLetter.reason = ''
      this.valid = false
      this.newDayOffLetter.dayOffCounting = 0
      this.newDayOffLetter.isApproved = false
      this.newDayOffLetter.isExisted = false
      this.newDayOffLetter.createdOn = ''
      this.newDayOffLetter.updatedOn = ''
      this.tab = null
    },
    goToNextTab() {
      if (this.currentTab === 1) {
        if (this.$refs.form.validate()) {
          this.currentTab += 1
        }
      } else if (this.currentTab === 2) {
        if (this.$refs.form2.validate()) {
          this.currentTab += 1
        }
      }
    },
    countDay(fDate, tDate) {
      console.log(fDate + tDate)
      const oneDay = 24 * 60 * 60 * 1000
      this.newDayOffLetter.dayOffCounting = Math.round((tDate.getTime() - fDate.getTime()) / oneDay)
      this.newDayOffLetter.dayOffCounting += 1
      let i = this.newDayOffLetter.dayOffCounting
      while (i !== 0) {
        if (fDate.getDay() === 0 || fDate.getDay() === 6) {
          this.newDayOffLetter.dayOffCounting -= 1
        }
        fDate.setDate(fDate.getDate() + 1)
        i -= 1
      }
    },
    async submitInfo() {
      if (this.$refs.form3.validate()) {
        const fDate = new Date(this.newDayOffLetter.fromDateTime)
        const tDate = new Date(this.newDayOffLetter.toDateTime)
        this.countDay(fDate, tDate)
        this.newDayOffLetter.createdOn = new Date().toISOString()
        this.newDayOffLetter.updatedOn = new Date().toISOString()

        await this.$store.dispatch('dayOffLetterStore/createNewDayOffLetter', {
          dayOffLetter: this.newDayOffLetter,
          token: this.$store.state.token,
        }).then(this.resetInfo()).finally(this.isCreateFormShow = false)

        await this.$store.dispatch('dayOffLetterStore/addDayOffLetterToEmployee', {
          token: this.$store.state.token,
          employeeId: this.getEmployee.id,
          dayOffLetterId: this.$store.state.dayOffLetterStore.createResponse.data.id,
        })
      }
    },
  },
}
</script>

<style scoped>
.full-width {
  width: 100%;
}
</style>
