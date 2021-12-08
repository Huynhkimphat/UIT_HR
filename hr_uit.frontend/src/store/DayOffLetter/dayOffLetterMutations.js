export default {
  resetState(state) {
    state.dayOffLetters = []
    state.dayOffLetter = {}
    state.createResponse = {}
    state.deleteResponse = {}
    state.recoverResponse = {}
    state.updateDayOffLetter = {}
    state.createEnable = true
  },
  createDayOffLetter(state, payload) {
    state.createResponse = payload
  },
  addDayOffLetterToEmployee(state, payload) {
    state.addResponse = payload
  },
  declineDayOffLetter(state, payload) {
    state.recoverResponse = payload
  },
  approveDayOffLetter(state, payload) {
    state.updateDayOffLetter = payload
  },
  unableCreate(state) {
    state.createEnable = false
  },
}
