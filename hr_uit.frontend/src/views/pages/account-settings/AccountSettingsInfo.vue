<template>
  <v-card
    flat
    class="pa-3 mt-2"
  >
    <v-form class="multi-col-validation">
      <v-card-text class="pt-5">
        <v-row>
          <v-col
            cols="12"
            md="6"
          >
            <v-menu
              v-model="dateOfBirthMenu"
              :close-on-content-click="false"
              :nudge-right="40"
              transition="scale-transition"
              offset-y
              min-width="auto"
            >
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-model="getEmployee.dateOfBirth"
                  label="Date Of Birth"
                  readonly
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="getEmployee.dateOfBirth"
                outlined
                dense
                @input="dateOfBirthMenu = false"
              ></v-date-picker>
            </v-menu>
          </v-col>
          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="getEmployee.phoneNumber"
              outlined
              dense
              label="Phone Number"
            ></v-text-field>
          </v-col>

          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="getEmployee.identityCard"
              outlined
              dense
              label="Identity Card"
            ></v-text-field>
          </v-col>

          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="getEmployee.primaryAddress.city"
              outlined
              dense
              label="City"
            ></v-text-field>
          </v-col>
          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="getEmployee.createdOn"
              outlined
              dense
              label="Created On"
              readonly
            ></v-text-field>
          </v-col>
        </v-row>
      </v-card-text>

      <v-card-text>
        <v-btn
          color="primary"
          class="me-3 mt-3"
        >
          Save changes
        </v-btn>
        <v-btn
          outlined
          class="mt-3"
          color="secondary"
          type="reset"
          @click.prevent="resetForm"
        >
          Cancel
        </v-btn>
      </v-card-text>
    </v-form>
  </v-card>
</template>

<script>
import { ref } from '@vue/composition-api'
import { mapGetters } from 'vuex'

export default {
  props: {
    informationData: {
      type: Object,
      default: () => {},
    },
  },
  data() {
    return {
      dateOfBirthMenu: false,
    }
  },
  setup(props) {
    const optionsLocal = ref(JSON.parse(JSON.stringify(props.informationData)))

    const resetForm = () => {
      optionsLocal.value = JSON.parse(JSON.stringify(props.informationData))
    }

    return { optionsLocal, resetForm }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployee']),
  },
  methods: {
  },
}
</script>
