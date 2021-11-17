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
    addResponse: {},
    updateResponse: {},
    resetResponse: {},
    attendance: {},
    error: {},
    timeCounting: { hrs: 0, mins: 0 },
  }),
  getters: attendanceGetters,
  mutations: attendanceMutations,
  actions: attendanceActions,
}
