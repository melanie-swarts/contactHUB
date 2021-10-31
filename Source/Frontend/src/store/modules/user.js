import { getUserInfo, loginByUsername, logout } from '@/api/login'
import { getToken, getIdentifierToken, getUserProfileToken, removeToken, removeIdentifierToken, setToken, removeUserProfileToken, setIdentifierToken, setUserProfileToken } from '@/utils/auth'
import UserService from '@/services/userService.js'
import jwt_decode from 'jwt-decode'
import Cookies from 'js-cookie'
import router from '@/router'

const user = {
  state: {
    status: '',
    systemUser: [],
    identifier: getIdentifierToken(),
    userProfile: getUserProfileToken(),
    code: '',
    token: getToken(),
    name: '',
    avatar: '',
    introduction: '',
    roles: [],
    setting: {
    articlePlatform: []
    }
  },

  mutations: {
    SET_CODE: (state, code) => {
      state.code = code
    },
    SET_TOKEN: (state, token) => {
      state.token = token
    },
    SET_INTRODUCTION: (state, introduction) => {
      state.introduction = introduction
    },
    SET_SETTING: (state, setting) => {
      state.setting = setting
    },
    SET_STATUS: (state, status) => {
      state.status = status
    },
    SET_PROFILE_EXISTS: (state, userProfile) => {
      state.userProfile = userProfile
    },
    SET_NAME: (state, name) => {
      state.name = name
    },
    SET_AVATAR: (state, avatar) => {
      state.avatar = avatar
    },
    SET_ROLES: (state, roles) => {
      state.roles = roles
    },
    SET_IDENTIFIER: (state, identifier) => {
      state.identifier = identifier
    },
    SET_USER: (state, systemUser) => {
      state.systemUser = systemUser
    },
    SET_REG_TYPE: (state, registrationTypes) => {
      state.registrationTypes = registrationTypes
    },
    SET_COUNTRIES: (state, countries) => {
      state.countries = countries
    }
  },

  actions: {
    LoginByUsername({ commit, dispatch }, userInfo) {
      return new Promise((resolve, reject) => {
        UserService.handleUserLogin(userInfo)
          .then(response => {
            this.token = jwt_decode(response)
            commit('SET_TOKEN', this.token.role)
            commit('SET_IDENTIFIER', this.token.identifier)
            Cookies.set('identifier', this.token.identifier)
            commit('SET_PROFILE_EXISTS', this.token.userProfile)
            setToken(this.token.role)
            setIdentifierToken(this.token.identifier)
            setUserProfileToken(this.token.userProfile)
            if (this.token.userProfile === false)
            {
              return router.push({ name: 'CreateAccount' })
            }
            dispatch('fetchSystemUser')
            resolve()
          })
          .catch(error => {
            reject(error)
          })
      })
    },

    RegisterNewUser({ commit, dispatch }, userInfo) {
      return new Promise((resolve, reject) => {
        UserService.registerNewUser(userInfo)
          .then(response => {
            console.log(response)
          })
          .catch(error => {
            console.log(0)
            console.log(error.message)
            reject(error)
          })
      })
    },

    CreateNewUser({ commit, dispatch }, systemUserInfo) {
      return new Promise((resolve, reject) => {
        UserService.createNewUser(systemUserInfo)
          .then(response => {
            console.log(response)
          })
          .catch(error => {
            console.log(0)
            console.log(error.message)
            reject(error)
          })
      })
    },

    ResetUserPassword({ commit, dispatch }, userInfo) {
      return new Promise((resolve, reject) => {
        UserService.resetUserPassword(userInfo)
          .then(response => {
            resolve()
          })
          .catch(error => {
            reject(error)
          })
      })
    },

    SetNewUserPassword({ commit, dispatch }, newPasswordInfo) {
      return new Promise((resolve, reject) => {
        UserService.setNewUserPassword(newPasswordInfo)
          .then(response => {
            resolve()
          })
          .catch(error => {
            reject(error)
          })
      })
    },

    fetchSystemUser({ commit, dispatch }) {
      return UserService.getUserByApplicationId(Cookies.get('identifier')).then(response => {
        commit('SET_USER', response.data[0])
        console.log(reponse.data)
        dispatch('fetchSystemUserInfo', response.data[0].id)
      })
    },

    fetchSystemUserInfo({ commit }, userId) {
      return UserService.getUserById(userId).then(response => {
        commit('SET_USER', response.data)
      })
    },

    fetchRegistrationTypes({ commit }) {
      return UserService.getRegistrationTypes().then(response => {
        commit('SET_REG_TYPE', response.data)
      })
    },

    fetchCountries({ commit }) {
      return UserService.getCountries().then(response => {
        commit('SET_COUNTRIES', response.data)
      })
    },
    GetUserInfo({ commit, state }) {
      return new Promise((resolve, reject) => {
        getUserInfo(state.token)
          .then(response => {
            if (!response.data) {
              reject('error')
            }
            const data = response.data

            if (data.roles && data.roles.length > 0) {
              commit('SET_ROLES', data.roles)
            } else {
              reject('getInfo: roles must be a non-null array !')
            }

            commit('SET_NAME', data.name)
            commit('SET_AVATAR', data.avatar)
            commit('SET_INTRODUCTION', data.introduction)

            resolve(response)
          })
          .catch(error => {
            reject(error)
          })
      })
    },

    LogOut({ commit, state }) {
      return new Promise((resolve, reject) => {
        logout(state.token)
          .then(() => {
            commit('SET_TOKEN', '')
            commit('SET_IDENTIFIER', '')
            commit('SET_PROFILE_EXISTS', '')
            commit('SET_ROLES', [])

            removeToken()
            removeIdentifierToken()
            removeUserProfileToken()
            resolve()
          })
          .catch(error => {
            reject(error)
          })
      })
    },

    FedLogOut({ commit }) {
      return new Promise(resolve => {
        commit('SET_TOKEN', '')
        commit('SET_IDENTIFIER', '')
        commit('SET_PROFILE_EXISTS', '')
        removeToken()
        removeIdentifierToken()
        removeUserProfileToken()
        resolve()
      })
    },

    ChangeRoles({ commit, dispatch }, role) {
      return new Promise(resolve => {
        commit('SET_TOKEN', role)
        setToken(role)
        getUserInfo(role).then(response => {
          const data = response.data
          commit('SET_ROLES', data.roles)
          commit('SET_NAME', data.name)
          commit('SET_AVATAR', data.avatar)
          commit('SET_INTRODUCTION', data.introduction)
          dispatch('GenerateRoutes', data)
          resolve()
        })
      })
    }
  }
}

export default user
