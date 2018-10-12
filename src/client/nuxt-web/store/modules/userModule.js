// import Vue from 'vue'
// import axios from '~/plugins/axios'

// export default {
//   state: {
//     currentUser: {
//       get UserName() {
//         return localStorage.getItem('currentUser_name')
//       },
//       get UserToken() {
//         return localStorage.getItem('currentUser_token')
//       }
//     }
//   },
//   mutations: {
//     setUser(state, { user_name, user_token }) {
//       // 在这里把用户名和token保存起来
//       localStorage.setItem('currentUser_name', user_name)
//       localStorage.setItem('currentUser_token', user_token)
//     }
//   },
//   actions: {
//     userLogin(context, { login, password }) {
//       this.axios
//         .get('/auth/login', {
//           login: login,
//           password: password
//         })
//         .then(
//           res => {
//             if (
//               res != null &&
//               res.body != undefined &&
//               'access-token' in res.body
//             ) {
//               var token = res.body['access-token']
//               if (token != '') {
//                 // 后端API验证通过
//                 // 调用上面mutations里定义的方法
//                 context.commit('setUser', {
//                   user_name: login,
//                   user_token: token
//                 })
//               }
//             } else {
//               alert('用户名密码错误')
//             }
//           },
//           res => {
//             alert('请求失败进入这里')
//           }
//         )
//     }
//   }
// }
