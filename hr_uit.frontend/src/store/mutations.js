// eslint-disable-next-line camelcase
import jwt_decode from 'jwt-decode'

export default {
  loginSucceed(state, payload) {
    state.token = payload.data
    state.isLoggedIn = true
    const tokenDecoded = jwt_decode(payload.data)
    state.role = tokenDecoded.type
    state.userId = tokenDecoded.employeeId
    state.username = tokenDecoded.username
  },

  loginFailed(state) {
    state.isLoggedIn = false
  },

  logout(state) {
    state.token = null
    state.isLoggedIn = false
    state.role = null
    state.userId = null
    state.username = null
  },
}
