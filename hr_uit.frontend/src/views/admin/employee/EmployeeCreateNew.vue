<template>
  <v-row>
    <v-col>
      <v-col
        offset-md="0"
        cols="12"
      >
        <v-btn
          color="primary"
          @click="toggleCreateEmployeeForm()"
        >
          New Employee
        </v-btn>
      </v-col>
      <v-expand-transition>
        <v-col
          v-show="isCreateEmployeeFormShow"
        >
          <v-tabs
            v-model="tab"
          >
            <v-tab
              href="#account"
              @click="currentTab=1"
            >
              Account
            </v-tab>
            <v-tab
              href="#profile"
              :disabled="currentTab===1"
              @click="currentTab=2"
            >
              Profile
            </v-tab>
            <v-tab
              href="#address"
              :disabled="currentTab!==3"
              @click="currentTab=3"
            >
              Address
            </v-tab>
          </v-tabs>
          <v-tabs-items
            v-model="tab"
            class="full-width"
          >
            <v-tab-item
              value="account"
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
                        :rules="nameRules"
                        :counter="20"
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
                        :rules="nameRules"
                        :counter="20"
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
            </v-tab-item>
            <v-tab-item
              value="profile"
            >
              <v-form
                ref="form2"
                v-model="valid"
              >
                <v-container>
                  <v-row>
                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="newEmployee.birthday"
                        :counter="20"
                        label="Birthday"
                        :rules="[v => !!v || 'Required']"
                        required
                      ></v-text-field>
                      <v-date-picker v-model="newEmployee.birthday"></v-date-picker>
                    </v-col>

                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="newEmployee.phoneNumber"
                        :rules="numberRules"
                        :counter="20"
                        label="Phone Number"
                        required
                      ></v-text-field>
                    </v-col>

                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="newEmployee.identityCard"
                        :rules="numberRules"
                        :counter="20"
                        label="Identity Card"
                        required
                      ></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-form>
            </v-tab-item>
            <v-tab-item
              value="address"
            >
              <v-form
                ref="form3"
                v-model="valid"
              >
                <v-container>
                  <v-row>
                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="newEmployee.primaryAddress.addressLine"
                        :rules="nameRules"
                        :counter="20"
                        label="Address Line"
                        required
                      ></v-text-field>
                    </v-col>

                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="newEmployee.primaryAddress.ward"
                        :rules="nameRules"
                        :counter="20"
                        label="Ward"
                        required
                      ></v-text-field>
                    </v-col>
                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="newEmployee.primaryAddress.district"
                        :rules="nameRules"
                        :counter="20"
                        label="District"
                        required
                      ></v-text-field>
                    </v-col>
                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="newEmployee.primaryAddress.city"
                        :rules="nameRules"
                        :counter="20"
                        label="City"
                        required
                      ></v-text-field>
                    </v-col>
                    <v-col
                      cols="12"
                      md="4"
                    >
                      <v-text-field
                        v-model="newEmployee.primaryAddress.country"
                        :rules="nameRules"
                        :counter="20"
                        label="Country"
                        required
                      ></v-text-field>
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
    </v-col>
  </v-row>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data() {
    return {
      expand2: false,
      newEmployee: {
        firstName: '',
        lastName: '',
        birthday: '',
        identityCard: '',
        phoneNumber: '',
        primaryAddress: {
          addressLine: '',
          ward: '',
          district: '',
          city: '',
          country: '',
          createdOn: Date.now,
          updatedOn: Date.now,
          isArchived: false,
        },
        primaryAccount: {
          email: '',
          password: 1,
          createdOn: Date.now,
          updatedOn: Date.now,
        },
        createdOn: Date.now,
        updatedOn: Date.now,
        isArchived: false,
      },
      currentTab: 1,
      isCreateEmployeeFormShow: false,
      tab: null,
      valid: false,
      nameRules: [
        v => !!v || 'Name is required',
        v => v.length <= 20 || 'Name must be less than 10 characters',
      ],
      numberRules: [
        v => !!v || 'Number is required',
        v => !Number.isNaN(parseFloat(v)) || 'Number is required',
        v => v.length >= 10 || 'Number must be more than 20 characters',
      ],
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+/.test(v) || 'Email must be valid',
      ],
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['createEmployee']),
  },
  watch: {
    currentTab(val) {
      if (val === 1) {
        this.tab = 'account'
      } else if (val === 2) {
        this.tab = 'profile'
      } else {
        this.tab = 'address'
      }
    },
  },
  methods: {
    toggleCreateEmployeeForm() {
      this.isCreateEmployeeFormShow = !this.isCreateEmployeeFormShow
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
    goToPreviousTab() {
      this.currentTab -= 1
    },
    resetInfo() {
      this.currentTab = 1
      this.newEmployee.firstName = ''
      this.newEmployee.lastName = ''
      this.newEmployee.primaryAccount.email = ''
      this.newEmployee.birthday = ''
      this.newEmployee.identityCard = ''
      this.newEmployee.phoneNumber = ''
      this.newEmployee.primaryAddress.addressLine = ''
      this.newEmployee.primaryAddress.ward = ''
      this.newEmployee.primaryAddress.district = ''
      this.newEmployee.primaryAddress.city = ''
      this.newEmployee.primaryAddress.country = ''
      this.newEmployee.valid = false
    },
    async submitInfo() {
      if (this.$refs.form3.validate()) {
        await this.$store.dispatch('employeeStore/createEmployee', this.newEmployee).finally(
          this.isCreateEmployeeFormShow = false,
        )
      }
    },
  },
}
</script>

<style scoped>
.full-width{
  width:100%;
}
</style>
