<template>
  <v-row>
    <v-col
      offset-md="0"
      cols="3"
    >
      <v-btn
        color="primary"
        @click="toggleCreateEmployeeForm()"
      >
        New Employee
      </v-btn>
    </v-col>
    <v-tabs
      v-if="isCreateEmployeeFormShow === true"
      v-model="tab"
    >
      <v-tab href="#account">
        Account
      </v-tab>
      <v-tab href="#profile">
        Profile
      </v-tab>
      <v-tab href="#address">
        Address
      </v-tab>
    </v-tabs>
    <v-tabs-items
      v-if="isCreateEmployeeFormShow === true"
      v-model="tab"
      class="full-width"
    >
      <v-tab-item
        value="account"
      >
        <v-form v-model="valid">
          <v-container>
            <v-row>
              <v-col
                cols="12"
                md="4"
              >
                <v-text-field
                  v-model="firstname"
                  :rules="nameRules"
                  :counter="10"
                  label="First name"
                  required
                ></v-text-field>
              </v-col>

              <v-col
                cols="12"
                md="4"
              >
                <v-text-field
                  v-model="lastname"
                  :rules="nameRules"
                  :counter="10"
                  label="Last name"
                  required
                ></v-text-field>
              </v-col>

              <v-col
                cols="12"
                md="4"
              >
                <v-text-field
                  v-model="email"
                  :rules="emailRules"
                  label="E-mail"
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
        Profile Adding
      </v-tab-item>
      <v-tab-item
        value="address"
      >
        Address Adding
      </v-tab-item>
    </v-tabs-items>
  </v-row>
</template>

<script>
export default {
  data() {
    return {
      isCreateEmployeeFormShow: false,
      tab: null,
      valid: false,
      firstname: '',
      lastname: '',
      nameRules: [
        v => !!v || 'Name is required',
        v => v.length <= 10 || 'Name must be less than 10 characters',
      ],
      email: '',
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+/.test(v) || 'E-mail must be valid',
      ],
    }
  },
  methods: {
    toggleCreateEmployeeForm() {
      this.isCreateEmployeeFormShow = !this.isCreateEmployeeFormShow
    },
  },
}
</script>

<style scoped>
.full-width{
  width:100%;
}
</style>
