var o = require('odata')
o().config({
  endpoint: process.env.BASE_API
})

export default {
  getCalendarEvents() {
    return o('calendarEvents')
      .get()
  },
  getCalendarEventById(id) {
    return o('calendarEvent/' + id)
      .get()
  },
  createCalendarEvent(data) {
    console.log(data)
    return new Promise(function(resolve, reject) {
      o('calendarEvents/createEvent')
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
  updateCalendarEvent(id, data) {
    return new Promise(function(resolve, reject) {
      o('CalendarEvent/' + id)
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
