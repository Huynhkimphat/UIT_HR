import salaryMutations from './salaryMutations'
import salaryGetters from './salaryGetters'
import salaryActions from './salaryActions'

export default {
  namespaced: true,
  state: () => ({
    salaries: [],
    createResponse: {},
    deleteResponse: {},
    recoverResponse: {},
    addResponse: {},
    resetResponse: {},
    salary: {},
    month: '',
    year: '',
    error: {},
    updateSalary: {},
    isFetchingData: true,
  }),
  mutations: salaryMutations,
  getters: salaryGetters,
  actions: salaryActions,
}
