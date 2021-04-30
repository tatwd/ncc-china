<template>
  <div id="ncc-updatepwd">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>修改密码</span>
      </div>
      <el-form
        ref="updatepwdform"
        :model="updatepwdform"
        :rules="rules"
        label-width="100px"
      >
        <el-form-item
          label="原密码"
          prop="useroldpwd"
        >
          <el-input
            v-model="updatepwdform.useroldpwd"
            type="password"
          />
        </el-form-item>
        <el-form-item
          label="新密码"
          prop="usernewpwd"
        >
          <el-input
            v-model="updatepwdform.usernewpwd"
            type="password"
          />
        </el-form-item>
        <el-form-item
          label="确认新密码"
          prop="usernewpwd2"
        >
          <el-input
            v-model="updatepwdform.usernewpwd2"
            type="password"
          />
        </el-form-item>
        <el-form-item>
          <el-button
            type="success"
            plain
            @click="submitForm('updatepwdform')"
          >
            保存修改
          </el-button>
        </el-form-item>
      </el-form>
    </el-card>
  </div>
</template>

<script>
// const Cookie = process.client ? require('js-cookie') : undefined

export default {
  data() {
    var validatenewpwd2 = (rule, value, callback) => {
      if (value !== this.updatepwdform.usernewpwd) {
        callback(new Error('两次输入密码不一致!'))
      } else {
        callback()
      }
    }
    return {
      updatepwdform: {
        useroldpwd: '',
        usernewpwd: '',
        usernewpwd2: ''
      },
      rules: {
        useroldpwd: [
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
        usernewpwd: [
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
        usernewpwd2: [
          {
            required: true,
            message: '请再次输入密码',
            trigger: 'blur'
          },
          {
            validator: validatenewpwd2,
            trigger: 'blur'
          }
        ]
      }
    }
  },
  methods: {
    submitForm(updatepwdform) {
      this.$refs[updatepwdform].validate(valid => {
        if (valid) {
          setTimeout(() => {
            this.$axios
              .put('v1/auth/password?type=update', {
                old: this.updatepwdform.useroldpwd,
                new: this.updatepwdform.usernewpwd
              })
              .then(res => {
                if (res.data.code === 0) {
                  this.$message({
                    showClose: true,
                    message: '密码修改成功，请重新登录！',
                    type: 'success'
                  })
                  this.$refs[updatepwdform].resetFields()
                  import('js-cookie').then(Cookie => {
                    Cookie.remove('auth')
                  })
                  window.location.href = '/user/signin'
                } else {
                  this.$message({
                    showClose: true,
                    message: '密码修改失败，请重试！',
                    type: 'error'
                  })
                }
              })
              .catch(err => {
                this.$message({
                  showClose: true,
                  message: err.message,
                  type: 'error'
                })
              })
          }, 100)
        }
      })
    }
  }
}
</script>
