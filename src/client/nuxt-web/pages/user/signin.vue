<template>
  <div id="signin">
    <el-form
      ref="loginform"
      :model="loginform"
      :rules="rules"
      class="login-box"
    >
      <el-form-item
        prop="useremail"
      >
        <el-input
          v-model="loginform.useremail"
          placeholder="请输入用户邮箱"
        />
      </el-form-item>
      <el-form-item
        prop="userpwd"
      >
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
      <el-form-item>
        <el-button
          type="primary"
          plain
        >
          通过 GitHub 账号登录
        </el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
export default {
  layout: 'account',

  data() {
    return {
      loginform: {
        useremail: '',
        userpwd: ''
      },
      rules: {
        useremail: [
          {
            required: true,
            message: '请输入邮箱地址',
            trigger: 'blur'
          },
          {
            type: 'email',
            message: '请输入正确的邮箱地址',
            trigger: ['blur', 'change']
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
          this.$axios.$get('https://api.github.com').then(res => {
            console.log(res.json)
          })
        } else {
          console.log('error submit!!')
          return false
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
  margin-top: -150px;
  margin-left: -120px;
  width: 240px;
  height: 300px;
  text-align: center;
  z-index: 1;
}
#signin .el-button {
  width: 100%;
}
</style>
