export default function({ store, error }) {
  if (!store.state.authUser) {
    error({
      message: '抱歉，您未登录！请先登录！',
      statusCode: 403
    })
    return redirect('/user/signin')
  }
}
