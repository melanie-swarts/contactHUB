import * as snackbar from '@/store/modules/snackbar.js'
import * as contacts from '@/store/modules/contacts.js'
import * as calendarEvents from '@/store/modules/calendarEvents.js'
import Vue from 'vue'
import Vuex from 'vuex'
import getters from './getters'
import app from './modules/app'
import errorLog from './modules/errorLog'
import permission from './modules/permission'
import tagsView from './modules/tagsView'
import user from './modules/user'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    app,
    contacts,
    calendarEvents,
    errorLog,
    permission,
    snackbar,
    tagsView,
    user
  },
  getters
})
