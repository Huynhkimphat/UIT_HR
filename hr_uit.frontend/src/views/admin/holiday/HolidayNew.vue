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
                  md="4"
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
                  md="4"
                >
                  <v-menu
                    ref="menu"
                    v-model="menu"
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
                        @click="menu = false"
                      >
                        Cancel
                      </v-btn>
                      <v-btn
                        text
                        color="primary"
                        @click="$refs.menu.save(newHoliday.dateOfHoliday)"
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
              class="mb-2 mw-105"
              color="primary"
              outlined
              type="reset"
              @click="resetInfo"
            >
              Reset
            </v-btn>
            <v-btn
              class="mb-2 mw-105"
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
      menu: false,
      newHoliday: {
        nameOfHoliday: '',
        dateOfHoliday: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10),
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
.mw-105{
  min-width: 105px !important;
}
</style>
