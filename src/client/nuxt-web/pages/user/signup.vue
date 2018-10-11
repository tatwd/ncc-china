<template>
  <div id="signup">
    <el-form
      ref="registerform"
      :model="registerform"
      :rules="rules"
      class="register-box"
    >
      <nuxt-link to="/">
        <h1>.NET Core</h1>
        <h2>专业中文社区</h2>
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
    var validateusername = (rule, value, callback) => {
      if (value === '') {
        return callback(new Error('用户名不能为空!'))
      }
    }
    var validateuseremail = (rule, value, callback) => {
      if (value === '') {
        return callback(new Error('用户邮箱不能为空!'))
      }
    }
    var validateuserpwd = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请输入密码!'))
      } else {
        if (this.registerform.userpwd2 !== '') {
          this.$refs.registerform.validateField('userpwd2')
        }
        callback()
      }
    }
    var validateuserpwd2 = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请再次输入密码!'))
      } else if (value !== this.registerform.userpwd) {
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
            validator: validateusername,
            trigger: 'blur'
          }
        ],
        useremail: [
          {
            validator: validateuseremail,
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
            validator: validateuserpwd,
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
            validator: validateuserpwd2,
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
    submitForm(registerform) {
      this.$refs[registerform].validate(valid => {
        if (valid) {
          this.$axios
            .$post('http://192.168.1.103:5000/api/auth/register', {
              username: this.registerform.username,
              email: this.registerform.useremail,
              password: this.registerform.userpwd
            })
            .then(res => {
              console.log(res)
            })
            .catch(console.log)
        } else {
          console.log('error submit!!')
          return false
        }
      })
      this.$refs[registerform].resetFields()
    }
  }
}
</script>

<style>
#signup .register-box {
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
#signup .register-box h1,
#signup .register-box h2 {
  margin-top: 0;
}
#signup .el-button {
  width: 100%;
}
</style>
