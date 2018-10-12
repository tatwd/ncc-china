import * as axios from 'axios'

let options = {} // The server-side needs a full url to works
if (process.server) {
  options.baseURL = 'https://gank.io/'
  // options.baseUrl = 'https://gank.io/'
  // options.baseURL = `http://${process.env.HOST || 'jsonplaceholder.typicode.com/'}:${process.env.PORT || 3000}/api`
}

export default axios.create(options)
