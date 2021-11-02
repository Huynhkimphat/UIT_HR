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
                  v-model="dateOfBirth"
                  label="dateOfBirth"
                  readonly
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                v-model="dateOfBirth"
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
              v-model="currentDataRecord.phoneNumber"
              outlined
              dense
              label="phoneNumber"
              @change="checkDate()"
            ></v-text-field>
          </v-col>

          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="currentDataRecord.identityCard"
              outlined
              dense
              label="identityCard"
            ></v-text-field>
          </v-col>

          <v-col
            cols="12"
            md="6"
          >
            <v-select
              v-model="currentDataRecord.primaryAddress.city"
              outlined
              dense
              label="City"
              :items="city"
            ></v-select>
          </v-col>
          <v-col
            cols="12"
            md="6"
          >
            <v-text-field
              v-model="createdOn"
              outlined
              dense
              label="createdOn"
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
import moment from 'moment'
import { mdiCalendar } from '@mdi/js'

export default {
  props: {
    informationData: {
      type: Object,
      default: () => {},
    },
    currentInfoData: {
      type: Object,
      default: () => {},
    },
  },
  data() {
    return {
      currentDataRecord: this.currentInfoData,
      city: ['HCMC', 'HN', 'DNC', 'KTC', 'HTC'],
      dateOfBirth: moment(String(this.currentInfoData.dateOfBirth)).format('YYYY-MM-DD'),
      createdOn: moment(String(this.currentInfoData.createdOn)).format('YYYY-MM-DD'),
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
  methods: {
    checkDate() {
      console.log('success')
      console.log(this.dateOfBirth)
    },
    frondEndDateFormat(date) {
      return moment(String(date)).format('MM/DD/YYYY')
    },
    backEndDateFormat(date) {
      return moment(String(date)).format('YYYY-MM-DD')
    },
  },
}
</script>
