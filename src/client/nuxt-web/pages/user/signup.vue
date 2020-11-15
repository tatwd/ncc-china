<template>
  <div id="signup">
    <el-form
      ref="registerform"
      :model="registerform"
      :rules="rules"
      class="register-box"
    >
      <nuxt-link
        to="/"
        class="mgtb15 d-block text--parmary"
      >
        <h1 class="mgt0 mgb0">.NET</h1>
        <h2 class="mgt0 mgb0">专业中文社区</h2>
      </nuxt-link>
      <el-form-item prop="username">
        <el-input
          v-model="registerform.username"
          placeholder="请输入用户名"
        />
      </el-form-item>
      <el-form-item prop="useremail">
        <el-input
          v-model="registerform.useremail"
          placeholder="请输入用户邮箱"
        />
      </el-form-item>
      <el-form-item prop="userpwd">
        <el-input
          v-model="registerform.userpwd"
          type="password"
          placeholder="请输入用户密码"
        />
      </el-form-item>
      <el-form-item prop="userpwd2">
        <el-input
          v-model="registerform.userpwd2"
          type="password"
          placeholder="请再次输入用户密码"
        />
      </el-form-item>
      <el-form-item>
        <el-button
          type="success"
          plain
          class="allw"
          @click="submitForm('registerform')"
        >
          注册账号
        </el-button>
      </el-form-item>
      <p>已有账号？马上去<nuxt-link to="/user/signin">登录</nuxt-link></p>
    </el-form>
  </div>
</template>

<script>
export default {
  layout: 'account',

  data() {
    var validateuserpwd2 = (rule, value, callback) => {
      if (value !== this.registerform.userpwd) {
        callback(new Error('两次输入密码不一致!'))
      } else {
        callback()
      }
    }
    return {
      registerform: {
        username: '',
        useremail: '',
        userpwd: '',
        userpwd2: ''
      },
      rules: {
        username: [
          {
            required: true,
            message: '请输入用户名',
            trigger: 'blur'
          }
        ],
        useremail: [
          {
            required: true,
            message: '请输入邮箱',
            trigger: 'blur'
          },
          {
            type: 'email',
            message: '请输入正确的邮箱地址',
            trigger: 'blur'
          }
        ],
        userpwd: [
          {
            required: true,
            message: '请输入密码',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 18,
            message: '长度在 6 到 18 个字符',
            trigger: 'blur'
          }
        ],
        userpwd2: [
          {
            required: true,
            message: '请再次输入密码',
            trigger: 'blur'
          },
          {
            validator: validateuserpwd2,
            trigger: 'blur'
          }
        ]
      }
    }
  },
  methods: {
    submitForm(registerform) {
      this.$refs[registerform].validate((valid, obj) => {
        if (valid) {
          let { username, useremail, userpwd } = this.registerform
          setTimeout(() => {
            this.$axios
              .$post('v1/auth/register', {
                username: username,
                email: useremail,
                password: userpwd
              })
              .then(res => {
                if (res.code === 0) {
                  this.$message({
                    showClose: true,
                    message: '注册成功！请登录！',
                    type: 'success'
                  })
                  this.$router.push('/user/signin')
                } else {
                  this.$message({
                    showClose: true,
                    message: '注册失败，请重新尝试！',
                    type: 'error'
                  })
                }
              })
              .catch(err => {
                console.log(err)
                this.$message({
                  showClose: true,
                  message: err.response.data.message,
                  type: 'error'
                })
              })
          }, 100)
        } else {
          this.$message({
            showClose: true,
            message: '请输入正确的用户注册信息！',
            type: 'error'
          })
          return false
        }
      })
      this.$refs[registerform].resetFields()
    }
  }
}
</script>

<style scoped>
.register-box {
  position: fixed;
  display: block;
  padding: 20px;
  top: 50%;
  left: 50%;
  margin-top: -230px;
  margin-left: -120px;
  width: 240px;
  height: 460px;
  text-align: center;
  z-index: 1;
}
</style>
