<template>
  <v-card
    flat
    class="pa-3 mt-2"
  >
    <v-card-text class="d-flex">
      <v-avatar
        rounded
        size="120"
        class="me-6"
      >
        <v-img :src="accountDataLocale.avatarImg"></v-img>
      </v-avatar>

      <!-- upload photo -->
      <div>
        <v-btn
          color="primary"
          class="me-3 mt-5"
          @click="$refs.refInputEl.click()"
        >
          <v-icon class="d-sm-none">
            {{ icons.mdiCloudUploadOutline }}
          </v-icon>
          <span class="d-none d-sm-block">Upload new photo</span>
        </v-btn>

        <input
          ref="refInputEl"
          type="file"
          accept=".jpeg,.png,.jpg,GIF"
          :hidden="true"
        />

        <v-btn
          color="error"
          outlined
          class="mt-5"
        >
          Reset
        </v-btn>
        <p class="text-sm mt-5">
          Allowed JPG, GIF or PNG. Max size of 800K
        </p>
      </div>
    </v-card-text>

    <v-card-text>
      <v-form class="multi-col-validation mt-6">
        <v-row>
          <v-col
            md="6"
            cols="12"
          >
            <v-text-field
              v-model="getEmployee.firstName"
              label="First Name"
              dense
              outlined
            ></v-text-field>
          </v-col>
          <v-col
            md="6"
            cols="12"
          >
            <v-text-field
              v-model="getEmployee.lastName"
              label="Last Name"
              dense
              outlined
            ></v-text-field>
          </v-col>
          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="getEmployee.primaryAccount.email"
              label="Email"
              dense
              outlined
              readonly
            ></v-text-field>
          </v-col>

          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="getRole"
              dense
              label="Role"
              outlined
            ></v-text-field>
          </v-col>

          <v-col
            cols="12"
            md="6"
          >
            <v-select
              v-model="getEmployee.isArchived"
              dense
              outlined
              label="Status"
              :items="status"
              item-text="status"
              item-value="value"
            ></v-select>
          </v-col>
          <v-col cols="12">
            <v-btn
              color="primary"
              class="me-3 mt-4"
              @click="save()"
            >
              Save changes
            </v-btn>
            <v-btn
              color="secondary"
              outlined
              class="mt-4"
              type="reset"
              @click.prevent="resetForm"
            >
              Cancel
            </v-btn>
          </v-col>
        </v-row>
      </v-form>
    </v-card-text>
  </v-card>
</template>

<script>
import { mapGetters } from 'vuex'
import { mdiAlertOutline, mdiCloudUploadOutline } from '@mdi/js'
import { ref } from '@vue/composition-api'

export default {
  props: {
    accountData: {
      type: Object,
      default: () => {},
    },
    currentAccountData: {
      type: Object,
      default: () => {},
    },
  },
  data() {
    return {
    }
  },
  setup(props) {
    const status = [
      { status: 'Active', value: false },
      { status: 'Inactive', value: true },
    ]

    const accountDataLocale = ref(JSON.parse(JSON.stringify(props.accountData)))

    const resetForm = () => {
      accountDataLocale.value = JSON.parse(JSON.stringify(props.accountData))
    }

    return {
      status,
      accountDataLocale,
      resetForm,
      icons: {
        mdiAlertOutline,
        mdiCloudUploadOutline,
      },
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
    ...mapGetters(['getRole']),
  },
  methods: {
    async save() {
      await this.$store.dispatch(
        'employeeStore/updateEmployee',
        {
          token: this.$store.state.token,
          data: this.getEmployee,
        },
      )
    },

  },
}
</script>
