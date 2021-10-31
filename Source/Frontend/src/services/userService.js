var o = require('odata')
o().config({
  endpoint: process.env.BASE_API
})

export default {
  getUsers() {
    return o('systemUser')
      .get()
  },
  getUserById(id) {
    return o('systemUser/' + id + '?$expand=AspNetUser')
      .get().then(
        {}
      )
  },
  getUserByApplicationId(userId) {
    return o('systemUser/' + userId)
      .get()
  },
  handleUserLogin(data) {
    return new Promise(function(resolve, reject) {
      o('systemUser/authenticate')
        .post(data)
        .save(
          function(result) {
            resolve(result)
          },
          function(status) {
            console.error(status) // error with status
            reject(status)
          }
        )
    })
  },
  registerNewUser(data) {
    return new Promise(function(resolve, reject) {
      o('systemUser/register')
        .post(data)
        .save(
          function(result) {
            resolve(result)
          },
          function(status) {
            console.error(status) // error with status
            reject(status)
          }
        )
    })
  },
  createNewUser(data) {
    return new Promise(function(resolve, reject) {
      o('systemUser/createAccount')
        .post(data)
        .save(
          function(result) {
            resolve(result)
          },
          function(status) {
            console.error(status) // error with status
            reject(status)
          }
        )
    })
  },
  resetUserPassword(data) {
    return new Promise(function(resolve, reject) {
      o('systemUser/resetPassword')
        .post(data)
        .save(
          function(result) {
            resolve(result)
          },
          function(status) {
            console.error(status) // error with status
            reject(status)
          }
        )
    })
  },
  setNewUserPassword(data) {
    return new Promise(function(resolve, reject) {
      o('systemUser/setNewPassword')
        .post(data)
        .save(
          function(result) {
            resolve(result)
          },
          function(status) {
            console.error(status) // error with status
            reject(status)
          }
        )
    })
  },
  getRegistrationTypes() {
    return o('registrationTypes')
      .get()
  },
  getCountries() {
    return o('countries')
      .get()
  }
}

