var request = require('supertest')
var app = require('../app')

describe('Health Check', () => {
  it('should reponse ok', async () => {
    var res = await request(app).get('/api/health');
    expect(res.statusCode).toEqual(200);
    expect(res.text).toEqual('ok');
  })
})