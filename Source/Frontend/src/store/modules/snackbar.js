export const namespaced = true

export const state = () => ({
  show: false,
  message: '',
  color: ''
})

export const mutations = {
  SET_SNACK(state, snackData) {
    state.show = snackData.show
    state.message = snackData.message
    state.color = snackData.color
  }
}

export const actions = {
  setSnack({ commit, dispatch }, snackData) {
    return commit('SET_SNACK', snackData)
  }
}
