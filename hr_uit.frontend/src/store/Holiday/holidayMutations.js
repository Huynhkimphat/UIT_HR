export default {
  getHolidays(state, payload) {
    state.holidays = payload
  },
  createHoliday(state, payload) {
    state.createResponse = payload
  },
  resetState(state) {
    state.holidays = []
    state.createResponse = {}
    state.deleteResponse = {}
    state.recoverResponse = {}
    state.holiday = {}
    state.error = {}
  },
}
