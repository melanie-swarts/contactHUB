import '@/styles/index.scss' // global css
import BootstrapVue from 'bootstrap-vue'
import Element from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import Cookies from 'js-cookie'
import 'normalize.css/normalize.css' // A modern alternative to CSS resets
import 'nprogress/nprogress.css'
import Vue from 'vue'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import App from './App'
import './errorLog' // error log
import * as filters from './filters' // global filters
import './icons' // icon
import i18n from './lang' // Internationalization
import './mock' // simulation data
import './permission' // permission control
import router from './router'
import store from './store/store'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import '@mdi/font/css/materialdesignicons.css'

Vue.use(Vuetify)
Vue.use(BootstrapVue)

Vue.use(Element, {
  size: Cookies.get('size') || 'medium', // set element-ui default size
  i18n: (key, value) => i18n.t(key, value)
})

// register global utility filters.
Object.keys(filters).forEach(key => {
  Vue.filter(key, filters[key])
})

Vue.config.productionTip = false

new Vue({
  el: '#app',
  router,
  vuetify: new Vuetify(),
  store,
  i18n,
  render: h => h(App)
})
