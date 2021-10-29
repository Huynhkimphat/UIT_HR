<template>
  <v-row>
    <v-col>
      <v-col
        cols="12"
        offset-md="0"
      >
        <v-btn
          color="primary"
          @click="toggleCreateEmployeeForm()"
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
                    v-model="newEmployee.firstName"
                    :counter="20"
                    :rules="nameRules"
                    label="First name"
                    required
                  ></v-text-field>
                </v-col>

                <v-col
                  cols="12"
                  md="4"
                >
                  <v-text-field
                    v-model="newEmployee.lastName"
                    :counter="20"
                    :rules="nameRules"
                    label="Last name"
                    required
                  ></v-text-field>
                </v-col>

                <v-col
                  cols="12"
                  md="4"
                >
                  <v-text-field
                    v-model="newEmployee.primaryAccount.email"
                    :rules="emailRules"
                    label="Email"
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
              :disabled="currentTab!==3"
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
      isCreateHolidayFormShow: false,
      valid: false,
      nameRules: [
        v => !!v || 'Name is required',
        v => v.length <= 20 || 'Name must be less than 10 characters',
      ],
    }
  },
}
</script>

<style scoped>

</style>
