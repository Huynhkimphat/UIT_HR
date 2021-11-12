<template>
  <v-card
    class="mt-5"
    flat
  >
    <v-form>
      <div class="px-3">
        <v-card-text class="pt-5">
          <v-row>
            <v-col
              cols="12"
              md="6"
              sm="8"
            >
              <!-- current password -->
              <v-text-field
                v-model="currentPassword"
                :append-icon="isCurrentPasswordVisible ? icons.mdiEyeOffOutline:icons.mdiEyeOutline"
                :error="!isFixCurrentPassword"
                :error-text="`Hi`"
                :type="isCurrentPasswordVisible ? 'text' : 'password'"
                dense
                label="Current Password"
                outlined
                required
                @blur="handleCurrentPassword()"
                @click:append="isCurrentPasswordVisible = !isCurrentPasswordVisible"
              ></v-text-field>

              <!-- new password -->
              <v-text-field
                v-model="newPassword"
                :append-icon="isNewPasswordVisible ? icons.mdiEyeOffOutline:icons.mdiEyeOutline"
                :type="isNewPasswordVisible ? 'text' : 'password'"
                dense
                label="New Password"
                outlined
                @click:append="isNewPasswordVisible = !isNewPasswordVisible"
              ></v-text-field>

              <!-- confirm password -->
              <v-text-field
                v-model="cPassword"
                :append-icon="isCPasswordVisible ? icons.mdiEyeOffOutline:icons.mdiEyeOutline"
                :type="isCPasswordVisible ? 'text' : 'password'"
                :error="isNewPasswordEnter && !isNewPasswordRepeat"
                :disabled="!isFixCurrentPassword"
                dense
                label="Confirm New Password"
                outlined
                @click="handleNewPassword()"
                @click:append="isCPasswordVisible = !isCPasswordVisible"
              ></v-text-field>
            </v-col>

            <v-col
              class="d-none d-sm-flex justify-center position-relative"
              cols="12"
              md="6"
              sm="4"
            >
              <v-img
                class="security-character"
                contain
                max-width="170"
                src="@/assets/images/3d-characters/pose-m-1.png"
              ></v-img>
            </v-col>
          </v-row>
        </v-card-text>
      </div>
      <!-- action buttons -->
      <v-card-text>
        <v-btn
          class="me-3 mt-3"
          color="primary"
          @click="handleSave()"
        >
          Save changes
        </v-btn>
        <v-btn
          class="mt-3"
          color="secondary"
          outlined
        >
          Cancel
        </v-btn>
      </v-card-text>
    </v-form>
  </v-card>
</template>

<script>
// eslint-disable-next-line object-curly-newline
import { mdiKeyOutline, mdiLockOpenOutline, mdiEyeOffOutline, mdiEyeOutline } from '@mdi/js'
import { ref } from '@vue/composition-api'
import { mapGetters } from 'vuex'
import bcrypt from 'bcryptjs'

export default {
  data() {
    return {
      isFixCurrentPassword: true,
      isNewPasswordEnter: false,
      isNewPasswordRepeat: false,
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
  },
  watch: {
    newPassword(val) {
      this.isNewPasswordEnter = val.trim().length > 0
    },
    cPassword(val) {
      this.isNewPasswordRepeat = val === this.newPassword
    },

    // isFixCurrentPassword(val) {
    //   if(!val){
    //   }
    // },
  },
  setup() {
    const isCurrentPasswordVisible = ref(false)
    const isNewPasswordVisible = ref(false)
    const isCPasswordVisible = ref(false)
    const currentPassword = ref('')
    const newPassword = ref('')
    const cPassword = ref('')

    return {
      isCurrentPasswordVisible,
      isNewPasswordVisible,
      currentPassword,
      isCPasswordVisible,
      newPassword,
      cPassword,
      icons: {
        mdiKeyOutline,
        mdiLockOpenOutline,
        mdiEyeOffOutline,
        mdiEyeOutline,
      },
    }
  },
  methods: {
    handleCurrentPassword() {
      bcrypt.compare(this.currentPassword, this.$store.getters['employeeStore/getEmployee'].primaryAccount.password, (err, result) => {
        this.isFixCurrentPassword = result
      })
    },
    handleNewPassword() {
      if (this.newPassword.trim().length > 0) {
        this.isNewPasswordEnter = true
      }
    },
    async handleSave() {
      if (this.isFixCurrentPassword && this.isNewPasswordEnter && this.isNewPasswordRepeat) {
        const salt = bcrypt.genSaltSync(10)
        const hashPassword = bcrypt.hashSync(this.cPassword, salt)
        await this.$store.dispatch('employeeStore/resetPassword',
          {
            employeeAccountId: this.getEmployee.primaryAccount.id,
            token: this.$store.state.token,
            resetPassword: {
              username: '',
              password: hashPassword,
            },
          }).then(() => {
          alert('Change Password Completed!!!')
        })
      } else {
        alert('Wrong Information')
      }
    },
  },
}
</script>

<style lang="scss" scoped>
.two-factor-auth {
  max-width: 25rem;
}

.security-character {
  position: absolute;
  bottom: -0.5rem;
}
</style>
