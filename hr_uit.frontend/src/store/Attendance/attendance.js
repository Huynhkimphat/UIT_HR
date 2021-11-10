import attendanceMutations from './attendanceMutations'
import attendanceGetters from './attendanceGetters'
import attendanceActions from './attendanceActions'

export default {
  namespaced: true,
  state: () => ({
    attendances: [],
    createResponse: {},
    deleteResponse: {},
    recoverResponse: {},
    updateResponse: {},
    resetResponse: {},
    attendance: {},
    error: {},
  }),
  getters: attendanceGetters,
  mutations: attendanceMutations,
  actions: attendanceActions,
}
