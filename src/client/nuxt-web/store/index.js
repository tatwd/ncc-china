const cookie = process.server ? require('cookie') : undefined

export const state = () => {
  return {
    auth: {
      token: null,
      user: null
    }
  }
}

export const mutations = {
  setToken(state, token) {
    state.auth.token = token
  },
  setUser(state, user) {
    state.auth.user = user
  },
  setAuth(state, auth) {
    state.auth = auth
  }
}

export const actions = {
  nuxtServerInit({ commit }, { req }) {
    let _cookie = req && req.headers.cookie
    if (_cookie) {
      let result = cookie.parse(_cookie)
      commit('setAuth', JSON.parse(result.auth))
    }
  }
}
