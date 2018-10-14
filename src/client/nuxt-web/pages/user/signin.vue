<template>
  <div id="signin">
    <el-form
      ref="loginform"
      :model="loginform"
      :rules="rules"
      class="login-box"
    >
      <nuxt-link to="/">
        <h1>.NET Core</h1>
        <h2>专业中文社区</h2>
      </nuxt-link>
      <el-form-item prop="username">
        <el-input
          v-model="loginform.username"
          placeholder="请输入用户名或用户邮箱"
        />
      </el-form-item>
      <el-form-item prop="userpwd">
        <el-input
          v-model="loginform.userpwd"
          type="password"
          placeholder="请输入用户密码"
        />
      </el-form-item>
      <el-form-item>
        <el-button
          type="success"
          plain
          @click="submitForm('loginform')"
        >
          登录
        </el-button>
      </el-form-item>
      <p>还没有账号？马上去<nuxt-link to="/user/signup">注册</nuxt-link></p>
    </el-form>
  </div>
</template>

<script>
const Cookie = process.client ? require('js-cookie') : undefined

export default {
  layout: 'account',
  middleware: 'unauth',

  data() {
    return {
      loginform: {
        username: '',
        userpwd: ''
      },
      rules: {
        username: [
          {
            required: true,
            message: '请输入用户名或用户邮箱',
            trigger: 'blur'
          },
          {
            message: '请输入用户名或用户邮箱',
            trigger: 'blur'
          }
        ],
        userpwd: [
          {
            required: true,
            message: '请输入用户密码',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 18,
            message: '长度在 6 到 18 个字符',
            trigger: 'blur'
          }
        ]
      }
    }
  },
  methods: {
    submitForm(loginform) {
      this.$refs[loginform].validate(valid => {
        if (valid) {
          let { username, userpwd } = this.loginform
          setTimeout(() => {
            this.$axios
              .$post('api/auth/login', {
                login: username,
                password: userpwd
              })
              .then(res => {
                if (res.code === 0) {
                  // console.log(res)
                  const { currentUser, tokenManager } = res.data
                  const auth = {
                    user: currentUser,
                    token: tokenManager.token
                  }
                  var expires =
                    (new Date(tokenManager.expireAt) - new Date()) /
                    (1000 * 60 * 60 * 24)
                  Cookie.set('auth', auth, { expires })
                  this.$store.commit('setAuth', auth)
                  this.$router.push('/')
                } else {
                  console.log(res.message)
                }
              })
              .catch(err => {
                console.log(err)
              })
          }, 1000)
        }
      })
      this.$refs[loginform].resetFields()
    }
  }
}
</script>

<style>
#signin .login-box {
  position: fixed;
  display: block;
  padding: 20px;
  top: 50%;
  left: 50%;
  margin-top: -170px;
  margin-left: -120px;
  width: 240px;
  height: 340px;
  text-align: center;
  z-index: 1;
}
#signin .login-box h1,
#signin .login-box h2 {
  margin-top: 0;
}
#signin .el-button {
  width: 100%;
}
</style>
