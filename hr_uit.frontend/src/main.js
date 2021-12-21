import '@/plugins/vue-composition-api'
import '@/styles/styles.scss'
import Vue from 'vue'
import moment from 'moment/moment'
import LoadScript from 'vue-plugin-load-script'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import store from './store'

Vue.config.productionTip = false

Vue.filter('humanizeDate',
  date => moment(String(date)).format('MM/DD/YYYY'))
Vue.filter('getFullDateTime', date => moment(String(date)).format('MMMM Do YYYY, h:mm:ss a'))
new Vue({
  router,
  LoadScript,
  store,
  vuetify,
  render: h => h(App),
}).$mount('#app')
