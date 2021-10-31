var o = require('odata')
o().config({
  endpoint: process.env.BASE_API
})

export default {
  getCalendarEventType() {
    return o('CalendarEventTypes')
      .get()
  },
  getCalendarEventTypeById(id) {
    return o('CalendarEventTypes/' + id)
      .get()
  },
  createCalendarEventType(data) {
    console.log(data)
    return new Promise(function(resolve, reject) {
      o('CalendarEventTypes')
        .post(data)
        .save(
          function(result) {
            resolve(result)
          },
          function(status) {
            console.error(status) // error with status
            console.log(status)
            reject(status)
          }
        )
    })
  },
  updateCalendarEventType(id, data) {
    return new Promise(function(resolve, reject) {
      o('CalendarEventTypes/' + id)
        .put(data)
        .save(
          function() {
            resolve(data)
          },
          function(status) {
            console.error(status) // error with status
            reject(status)
          }
        )
    })
  }
}
