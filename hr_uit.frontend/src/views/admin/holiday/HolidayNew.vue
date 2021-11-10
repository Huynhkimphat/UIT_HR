<template>
  <v-row>
    <v-col>
      <v-col>
        <v-btn
          color="primary"
          @click="toggleNewHolidayForm()"
        >
          New Company's Holiday
        </v-btn>
      </v-col>
      <v-expand-transition>
        <v-col
          v-show="isCreateHolidayFormShow"
        >
          <v-form
            ref="form"
            v-model="valid"
          >
            <v-container>
              <v-row>
                <v-col
                  cols="12"
                  md="6"
                >
                  <v-text-field
                    v-model="newHoliday.nameOfHoliday"
                    :rules="nameRules"
                    label="Name of Holiday"
                    required
                  ></v-text-field>
                </v-col>
                <v-col
                  cols="12"
                  md="6"
                >
                  <v-menu
                    ref="menuDate"
                    v-model="menuDate"
                    :close-on-content-click="false"
                    :return-value.sync="newHoliday.dateOfHoliday"
                    transition="scale-transition"
                    offset-y
                    min-width="auto"
                  >
                    <template v-slot:activator="{ on, attrs }">
                      <v-text-field
                        v-model="newHoliday.dateOfHoliday"
                        label="Holiday's Date"
                        prepend-icon="mdi-calendar"
                        readonly
                        v-bind="attrs"
                        v-on="on"
                      ></v-text-field>
                    </template>
                    <v-date-picker
                      v-model="newHoliday.dateOfHoliday"
                      no-title
                      scrollable
                    >
                      <v-spacer></v-spacer>
                      <v-btn
                        text
                        color="primary"
                        @click="menuDate = false"
                      >
                        Cancel
                      </v-btn>
                      <v-btn
                        text
                        color="primary"
                        @click="$refs.menuDate.save(newHoliday.dateOfHoliday)"
                      >
                        OK
                      </v-btn>
                    </v-date-picker>
                  </v-menu>
                </v-col>
                <v-col
                  cols="12"
                  md="6"
                >
                  <v-menu
                    ref="menuFrom"
                    v-model="menuFrom"
                    :close-on-content-click="false"
                    :return-value.sync="newHoliday.primaryHolidayCreate.fromDate"
                    transition="scale-transition"
                    offset-y
                    min-width="auto"
                  >
                    <template v-slot:activator="{ on, attrs }">
                      <v-text-field
                        v-model="newHoliday.primaryHolidayCreate.fromDate"
                        label="From Date"
                        prepend-icon="mdi-calendar"
                        readonly
                        v-bind="attrs"
                        v-on="on"
                      ></v-text-field>
                    </template>
                    <v-date-picker
                      v-model="newHoliday.primaryHolidayCreate.fromDate"
                      no-title
                      scrollable
                    >
                      <v-spacer></v-spacer>
                      <v-btn
                        text
                        color="primary"
                        @click="menuFrom = false"
                      >
                        Cancel
                      </v-btn>
                      <v-btn
                        text
                        color="primary"
                        @click="$refs.menuFrom.save(newHoliday.primaryHolidayCreate.fromDate)"
                      >
                        OK
                      </v-btn>
                    </v-date-picker>
                  </v-menu>
                </v-col>
                <v-col
                  cols="12"
                  md="6"
                >
                  <v-menu
                    ref="menuTo"
                    v-model="menuTo"
                    :close-on-content-click="false"
                    :return-value.sync="newHoliday.primaryHolidayCreate.toDate"
                    transition="scale-transition"
                    offset-y
                    min-width="auto"
                  >
                    <template v-slot:activator="{ on, attrs }">
                      <v-text-field
                        v-model="newHoliday.primaryHolidayCreate.toDate"
                        label="To Date"
                        prepend-icon="mdi-calendar"
                        readonly
                        v-bind="attrs"
                        v-on="on"
                      ></v-text-field>
                    </template>
                    <v-date-picker
                      v-model="newHoliday.primaryHolidayCreate.toDate"
                      no-title
                      scrollable
                    >
                      <v-spacer></v-spacer>
                      <v-btn
                        text
                        color="primary"
                        @click="menu = false"
                      >
                        Cancel
                      </v-btn>
                      <v-btn
                        text
                        color="primary"
                        @click="$refs.menuTo.save(newHoliday.primaryHolidayCreate.toDate)"
                      >
                        OK
                      </v-btn>
                    </v-date-picker>
                  </v-menu>
                </v-col>
              </v-row>
            </v-container>
          </v-form>
          <v-col
            cols="12"
            offset-md="1"
          >
            <v-btn
              class="mb-2"
              color="primary"
              @click="submitInfo"
            >
              Submit
            </v-btn>
          </v-col>
        </v-col>
      </v-expand-transition>
    </v-col>
  </v-row>
</template>

<script>
export default {
  data() {
    return {
      menuDate: false,
      menuFrom: false,
      menuTo: false,
      newHoliday: {
        nameOfHoliday: '',
        dateOfHoliday: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10),
        primaryHolidayCreate: {
          fromDate: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10),
          toDate: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10),
          isArchived: false,
        },
        isArchived: false,
      },
      isCreateHolidayFormShow: false,
      valid: false,
      nameRules: [
        v => !!v || 'Name is required',
      ],
    }
  },
  methods: {
    toggleNewHolidayForm() {
      this.isCreateHolidayFormShow = !this.isCreateHolidayFormShow
    },
    resetInfo() {
      this.newHoliday.nameOfHoliday = ''
      this.newHoliday.dateOfHoliday = (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)
    },
    async submitInfo() {
      if (this.$refs.form.validate()) {
        await this.$store.dispatch('holidayStore/createHoliday', {
          token: this.$store.state.token,
          newHoliday: this.newHoliday,
        })
          .then(

            // this.resetInfo(),
          )
          .finally(
            this.isCreateHolidayFormShow = false,
          )
      }
    }
    ,

  },
}
</script>

<style scoped>
</style>
