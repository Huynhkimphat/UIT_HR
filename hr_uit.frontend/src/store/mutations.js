// eslint-disable-next-line camelcase
import jwt_decode from 'jwt-decode'

export default {
  login(state, payload) {
    state.token = payload
    state.isLoggedIn = true
    const tokenDecoded = jwt_decode(payload)
    state.role = tokenDecoded.type
    state.userId = tokenDecoded.employeeId
    state.username = tokenDecoded.username
  },

  logout(state) {
    state.token = null
    state.isLoggedIn = false
    state.role = null
    state.userId = null
    state.username = null
  },
}
