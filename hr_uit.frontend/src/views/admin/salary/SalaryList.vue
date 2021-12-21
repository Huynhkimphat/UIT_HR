<template>
  <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
          <th class="text-uppercase text-center ">
            Id
          </th>
          <th class="text-center text-uppercase">
            FullName
          </th>
          <th class="text-center text-uppercase">
            Email
          </th>
          <th class="text-center text-uppercase">
            Status
          </th>
          <th class="text-center text-uppercase">
            Send
          </th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(item, index) in getEmployees"
          :key="item.id"
        >
          <td class="text-center">
            {{ item.id }}
          </td>
          <td class="text-center">
            {{ item.firstName + ' ' + item.lastName }}
          </td>
          <td class="text-center">
            {{ item.primaryAccount.email }}
          </td>
          <td
            v-if="getSalaries[index] == null"
            class="text-center"
          >
            <span
              class="waitingStatus"
            >
              WAITING
            </span>
          </td>
          <td
            v-else
            class="text-center"
          >
            <span
              class="successStatus"
            >
              SUCCESS
            </span>
          </td>
          <td
            v-if="getSalaries[index] == null"
            class="text-center"
          >
            <v-btn
              class="sendBtn"
              @click="sendSalary(item.firstName + item.lastName)"
            >
              SEND
            </v-btn>
          </td>
          <td
            v-else
            class="text-center"
          >
            <v-btn
              class="closedBtn"
              disabled
            >
              CLOSED
            </v-btn>
          </td>
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>

<script>
import { mapGetters } from 'vuex'
import { jsPDF } from 'jspdf'
import autoTable from 'jspdf-autotable'

export default {
  data() {
    return {
      salary: {
        primarySalaryDetail: {
          estimatedSalary: 10000000,
          estimatedDayWorking: 30,
          realityDayWorking: 30,
          bonus: 1000000,
          taxes: 1000000,
          minus: 0,
          finalSalary: 10000000,
          isArchived: false,
        },
        month: '',
        year: '',
        isExisted: false,
        isArchived: false,
      },
    }
  },
  computed: {
    ...mapGetters('employeeStore', ['getEmployees']),
    ...mapGetters('salaryStore', ['getSalaries', 'getNewSalary']),
  },
  watch: {
    getNewSalary() {
      this.initialize()
      this.reloadState()
    },
  },
  mounted() {
    this.initialize()
    const smtpjs = document.createElement('script')
    smtpjs.setAttribute('src', 'https://smtpjs.com/v3/smtp.js')
    document.head.appendChild(smtpjs)
  },
  methods: {
    createPDF(fullName) {
      // eslint-disable-next-line new-cap
      const doc = new jsPDF('landscape')
      const companyInfo = 'HR-UIT Company \n'
        + 'Address: INFORMATION AND TECHNOLOGY UNIVERSITY \n'
        + 'Phone Number: 099999'
      doc.text(companyInfo, 15, 20, { baseline: 'top' })
      const header = `SALARY INFORMATION ${this.salary.month}/${this.salary.year}`
      doc.text(header, 100, 60, { baseline: 'top' })
      autoTable(doc, {
        head: [['FULL NAME', 'ROLE', 'ESTIMATED SALARY', 'ESTIMATED DAY WORKING', 'REALITY DAY WORKING', 'BONUS', 'TAXES', 'MINUS', 'FINAL SALARY', 'SIGN']],
        body: [
          [fullName, 'Staff', this.salary.primarySalaryDetail.estimatedSalary,
            this.salary.primarySalaryDetail.estimatedDayWorking,
            this.salary.primarySalaryDetail.realityDayWorking,
            this.salary.primarySalaryDetail.bonus,
            this.salary.primarySalaryDetail.taxes,
            this.salary.primarySalaryDetail.minus,
            this.salary.primarySalaryDetail.finalSalary,
            '',
          ],
        ],
        startY: 80,
      })

      const salaryPDF = doc.output('datauristring')
      const subject = `SALARY INFORMATION (${this.salary.month}/${this.salary.year}) FROM UIT-HR COMPANY.`
      const body = `Hello ${fullName}
      We sending you salary information,
      Please check and reply to this email address if you have any problems with your salary receive.
      Sincerely!`

      // eslint-disable-next-line no-undef
      Email.send({
        Host: 'smtp.gmail.com',
        Username: 'uithrcompany@gmail.com',
        Password: 'lehoang2210kt',
        To: '19521533@gm.uit.edu.vn',
        From: 'uithrcompany@gmail.com',
        Subject: subject,
        Body: body,
        Attachments: [{
          name: 'SALARY.pdf',
          data: salaryPDF,
        }],
      }).then(message => alert(message))
    },

    async sendSalary(name) {
      this.salary.month = this.$store.state.salaryStore.month
      this.salary.year = this.$store.state.salaryStore.year
      await this.$store.dispatch('salaryStore/createSalary', {
        token: this.$store.state.token,
        salary: this.salary,
      })
      await this.$store.dispatch('salaryStore/addSalaryToEmployee', {
        token: this.$store.state.token,
        salaryId: this.getNewSalary.data.id,
        employeeId: this.$store.state.userId,
      })
      this.createPDF(name)
    },
    async initialize() {
      await this.$store.dispatch('employeeStore/getEmployees', this.$store.state.token)
    },
    async reloadState() {
      await this.$store.dispatch('salaryStore/getSalaryByYearMonth', {
        token: this.$store.state.token,
        year: this.$store.state.salaryStore.year,
        month: this.$store.state.salaryStore.month,
      })
    },
  },
}
</script>

<style scoped>
.waitingStatus {
  color: red;
}
.successStatus {
  color: #00C853;
}
.sendBtn {
  color: #00C853;
  font-weight: bold;
}
.closedBtn {
  color: red;
  font-weight: bold;
}
</style>
