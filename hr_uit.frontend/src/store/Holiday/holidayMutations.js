export default {
  getHolidays(state, payload) {
    state.holidays = payload
  },
  createHoliday(state, payload) {
    state.createResponse = payload
  },
}
