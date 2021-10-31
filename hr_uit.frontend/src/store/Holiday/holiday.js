import holidayMutations from './holidayMutations'
import holidayGetters from './holidayGetters'
import holidayActions from './holidayActions'

export default {
  namespaced: true,
  state: () => ({
    holidays: [],
    createResponse: {},
    deleteResponse: {},
    recoverResponse: {},
    holiday: {},
    error: {},
  }),
  getters: holidayGetters,
  mutations: holidayMutations,
  actions: holidayActions,
}
