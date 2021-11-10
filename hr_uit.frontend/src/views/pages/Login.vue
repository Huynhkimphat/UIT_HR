<template>
  <div class="auth-wrapper auth-v1">
    <div class="auth-inner">
      <v-card class="auth-card">
        <!-- logo -->
        <v-card-title class="d-flex align-center justify-center py-7">
          <router-link
            class="d-flex align-center"
            to="/"
          >
            <v-img
              :src="require('@/assets/images/logos/logo.svg')"
              alt="logo"
              class="me-3 "
              contain
              max-height="30px"
              max-width="30px"
            ></v-img>

            <h2 class="text-2xl font-weight-semibold">
              HR_UIT
            </h2>
          </router-link>
        </v-card-title>

        <!-- title -->
        <v-card-text>
          <p class="text-2xl font-weight-semibold text--primary mb-2">
            Welcome to HR_UIT! 👋🏻
          </p>
          <p class="mb-2">
            Please sign-in to your account
          </p>
        </v-card-text>

        <!-- login form -->
        <v-card-text>
          <v-form>
            <v-text-field
              v-model="email"
              class="mb-3"
              hide-details
              label="Email"
              outlined
              placeholder="john@example.com"
            ></v-text-field>

            <v-text-field
              v-model="password"
              :append-icon="isPasswordVisible ? icons.mdiEyeOffOutline : icons.mdiEyeOutline"
              :type="isPasswordVisible ? 'text' : 'password'"
              hide-details
              label="Password"
              outlined
              placeholder="············"
              @click:append="isPasswordVisible = !isPasswordVisible"
            ></v-text-field>
            <v-alert
              v-if="!isLoggedIn && !loading && logged"
              dense
              outlined
              type="error"
              class="mt-1"
            >
              Invalid <strong>username</strong> and/or <strong>password</strong> !!!
            </v-alert>
            <v-alert
              v-if="isLoggedIn && !loading && logged"
              dense
              outlined
              type="success"
              class="mt-1"
            >
              Login Success. Yay!!!
            </v-alert>
            <div class="d-flex align-center justify-space-between flex-wrap">
              <v-checkbox
                class="me-3 mt-1"
                hide-details
                label="Remember Me"
              >
              </v-checkbox>

              <!-- forgot link -->
              <a
                class="mt-1"
                href="javascript:void(0)"
              >
                Forgot Password?
              </a>
            </div>

            <v-btn
              block
              class="mt-6"
              color="primary"
              @click="login"
            >
              {{ loading? "Loading...": "Login" }}
            </v-btn>
          </v-form>
        </v-card-text>
      </v-card>
    </div>

    <!-- background triangle shape  -->
    <img
      :src="require(`@/assets/images/misc/mask-${$vuetify.theme.dark ? 'dark':'light'}.png`)"
      class="auth-mask-bg"
      height="173"
    >

    <!-- tree -->
    <v-img
      class="auth-tree"
      height="185"
      src="@/assets/images/misc/tree.png"
      width="247"
    ></v-img>

    <!-- tree  -->
    <v-img
      class="auth-tree-3"
      height="289"
      src="@/assets/images/misc/tree-3.png"
      width="377"
    ></v-img>
  </div>
</template>

<script>
// eslint-disable-next-line object-curly-newline
import {
  mdiEyeOutline,
  mdiEyeOffOutline,
} from '@mdi/js'
import { ref } from '@vue/composition-api'
import { mapGetters } from 'vuex'

export default {
  data() {
    return {
      logged: false,
      loading: false,
    }
  },
  computed: {
    ...mapGetters(['isLoggedIn']),
  },
  methods: {
    async login() {
      this.loading = true
      await this.$store.dispatch('login', {
        username: this.email,
        password: this.password,
      })

      this.loading = false
      this.logged = true
      if (this.$store.getters.isLoggedIn) {
        await this.$router.push({ name: 'dashboard' })
        await this.$store.dispatch('employeeStore/getEmployeeByCurrentId', {
          token: this.$store.state.token,
          userId: this.$store.state.userId,
        })
      }
    },
  },
  setup() {
    const isPasswordVisible = ref(false)
    const email = ref('')
    const password = ref('')

    return {
      isPasswordVisible,
      email,
      password,
      icons: {
        mdiEyeOutline,
        mdiEyeOffOutline,
      },
    }
  },
}
</script>

<style lang="scss">
@import '~@/plugins/vuetify/default-preset/preset/pages/auth.scss';
</style>
