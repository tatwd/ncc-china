export default function({ $axios, redirect, store, isServer }) {
  console.log('isServer:', isServer)
  let auth = store.state.auth
  if (auth) {
    $axios.setToken(auth.token, 'Bearer')
  }
  // $axios.onRequest(req => {
  //   let token = store.state.auth.token
  //   $axios.setToken(token, 'Bearer')
  // })
  $axios.onError(error => {
    const code = parseInt(error.response && error.response.status)
    if (code === 401) {
      redirect('/user/signin')
    } else if (code === 404) {
      redirect('/')
    } else {
      console.log(error)
    }
  })
}
