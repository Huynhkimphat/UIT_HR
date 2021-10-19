import '@/plugins/vue-composition-api'
import '@/styles/styles.scss'
import Vue from 'vue'
import moment from 'moment/moment'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import store from './store'

Vue.config.productionTip = false

Vue.filter('humanizeDate',
  date => moment(date).format('MMMM Do YYYY'))

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App),
}).$mount('#app')
