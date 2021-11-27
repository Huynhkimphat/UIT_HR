import dayOffLetterMutations from './dayOffLetterMutations'
import dayOffLetterGetters from './dayOffLetterGetters'
import dayOffLetterActions from './dayOffLetterActions'

export default {
  namespaced: true,
  state: () => ({
    dayOffLetters: [],
    createResponse: {},
    deleteResponse: {},
    recoverResponse: {},
    resetResponse: {},
    dayOffLetter: {},
    error: {},
    updateDayOffLetter: {},
    addResponse: {},
    createEnable: true,
  }),
  mutations: dayOffLetterMutations,
  getters: dayOffLetterGetters,
  actions: dayOffLetterActions,
}
