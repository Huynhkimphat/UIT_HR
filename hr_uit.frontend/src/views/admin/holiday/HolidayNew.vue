<template>
  <v-row>
    <v-col>
      <v-col
        cols="12"
        offset-md="0"
      >
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
                    v-model="newHoliday.name"
                    :counter="20"
                    :rules="nameRules"
                    label="Name of Holiday"
                    required
                  ></v-text-field>
                </v-col>
              </v-row>
            </v-container>
          </v-form>
          <v-col
            cols="2"
            offset-md="5"
          >
            <v-btn
              class="mx-2"
              color="primary"
              outlined
              type="reset"
              @click="resetInfo"
            >
              Reset
            </v-btn>
            <v-btn
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
      newHoliday: {
        name: '',
        createdOn: Date.now,
        updatedOn: Date.now,
      },
      isCreateHolidayFormShow: false,
      valid: false,
      nameRules: [
        v => !!v || 'Name is required',
        v => v.length <= 20 || 'Name must be less than 10 characters',
      ],
    }
  },
  methods: {
    toggleNewHolidayForm() {
      this.isCreateHolidayFormShow = !this.isCreateHolidayFormShow
    },
    resetInfo() {
      this.newHoliday.name = ''
      this.newHoliday.createOn = Date.now
      this.newHoliday.updatedOn = Date.now
    },
    async submitInfo() {
      if (this.$refs.form.validate()) {
        await this.$store.dispatch('holidayStore/createHoliday', this.newHoliday).then(
          this.resetInfo(),
        ).finally(
          this.isCreateEmployeeFormShow = false,
        )
      }
    },

  },
}
</script>

<style scoped>

</style>
