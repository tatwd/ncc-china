export default function({ store, error, redirect }) {
  if (!store.state.auth.token) {
    // error({
    //   message: '抱歉，您未登录！请先登录！',
    //   statusCode: 403
    // })
    return redirect('/user/signin')
  }
}
