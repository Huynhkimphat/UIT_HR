import dayOffMutations from './dayOffMutations'
import dayOffGetters from './dayOffGetters'
import dayOffActions from './dayOffActions'

export default {
  namespaced: true,
  state: () => ({
    daysOff: [],
    createResponse: {},
    deleteResponse: {},
    recoverResponse: {},
    resetResponse: {},
    dayOff: {},
    error: {},
    updateDayOff: {},
    addResponse: {},
  }),
  mutations: dayOffMutations,
  getters: dayOffGetters,
  actions: dayOffActions,
}
