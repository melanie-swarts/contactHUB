var o = require('odata')
o().config({
  endpoint: process.env.BASE_API
})

export default {
  getSystems() {
    return o('onlineSystems')
      .get()
  },
  getSystemById(id) {
    return o('onlineSystems/' + id)
      .get()
  }
}
