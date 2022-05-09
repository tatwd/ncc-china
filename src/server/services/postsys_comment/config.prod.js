module.exports = {
  secretKey: 'this_is_a_test_security_key',
  nccPostsysDbConn: `mongodb://root:test123@ncc.postsys:27017/ncc_postsys?authSource=admin`,
  jaegerCollectorEndpoint: 'http://test_jaeger:14268/api/traces'
}
