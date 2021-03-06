import { param2Obj } from '@/utils'

const userMap = {
  admin: {
    roles: ['admin'],
    token: 'admin',
    avatar: 'https://png.pngtree.com/svg/20170602/user_circle_1048392.png',
    name: 'Super Admin'
  },
  user: {
    roles: ['user'],
    token: 'user',
    avatar: 'https://png.pngtree.com/svg/20170602/user_circle_1048392.png',
    name: 'User'
  }
}

export default {
  loginByUsername: config => {
    const { username } = JSON.parse(config.body)
    return userMap[username]
  },
  getUserInfo: config => {
    const { token } = param2Obj(config.url)
    if (userMap[token]) {
      return userMap[token]
    } else {
      return false
    }
  },
  logout: () => 'success'
}
