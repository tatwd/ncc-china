export default function({ $axios, redirect, store }) {
  let token = store.state.auth.token
  $axios.setToken(token, 'Bearer')
  $axios.onError(error => {
    const code = parseInt(error.response && error.response.status)
    if (code === 401) {
      redirect('/user/signin')
    } else if (code === 404) {
      redirect('/')
    }
  })
}
