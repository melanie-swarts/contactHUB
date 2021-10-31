var o = require('odata')
o().config({
  endpoint: process.env.BASE_API
})

export default {
  getContact() {
    return o('contacts')
      .get()
  },
  getContactById(id) {
    return o('contact/' + id)
      .get()
  },
  createContact(data) {
    console.log(data)
    return new Promise(function(resolve, reject) {
      o('contact/createContact')
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
  updateContact(id, data) {
    return new Promise(function(resolve, reject) {
      o('Contacts/' + id)
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
