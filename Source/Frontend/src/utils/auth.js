import Cookies from 'js-cookie'

const TokenKey = 'Admin-Token'

export function getToken() {
  return Cookies.get(TokenKey)
}

export function getIdentifierToken() {
  return Cookies.get('identifier')
}

export function getUserProfileToken() {
  return Cookies.get('userProfile')
}

export function setToken(token) {
  return Cookies.set(TokenKey, token)
}

export function setIdentifierToken(token) {
  return Cookies.set('identifier', token)
}

export function setUserProfileToken(token) {
  return Cookies.set('userProfile', token)
}

export function removeToken() {
  return Cookies.remove(TokenKey)
}

export function removeIdentifierToken() {
  return Cookies.remove('identifier')
}

export function removeUserProfileToken() {
  return Cookies.remove('userProfile')
}
