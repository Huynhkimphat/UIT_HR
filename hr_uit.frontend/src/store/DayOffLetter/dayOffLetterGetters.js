export default {
  getDayOffLetters(state) {
    return state.dayOffLetters
  },
  createDayOffLetter(state) {
    return state.createResponse
  },
  addDayOffLetterToEmployee(state) {
    return state.addResponse
  },
  approveDayOffLetter(state) {
    return state.updateDayOffLetter
  },
  declineDayOffLetter(state) {
    return state.recoverResponse
  },
}
