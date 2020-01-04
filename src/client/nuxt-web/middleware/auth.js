export default function({ store, redirect }) {
  let auth = store.state.auth
  if (auth && auth.token) {
    return redirect('/')
  }
}
