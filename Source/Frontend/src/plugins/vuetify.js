import Vue from 'vue'
import Vuetify from 'vuetify/lib'
import 'vuetify/src/stylus/app.styl'

export default new Vuetify({
  icons: {
    iconfont: 'md',  // 'mdi' || 'mdiSvg' || 'md' || 'fa' || 'fa4'
  },
  theme: {
    themes: {
      light: {
        primary: '#3C565B',
        secondary: '#b0bec5',
        anchor: '#8c9eff',
      },
    },
  },
})
