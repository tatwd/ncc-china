<template>
  <div id="ncc-updatepwd">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>修改密码</span>
      </div>
      <div>
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
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  data() {
    var validateoldpwd = (rule, value, callback) => {
      if (value === '') {
        return callback(new Error('原密码不能为空!'))
      }
    }
    var validatenewpwd = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请输入新密码!'))
      } else {
        if (this.updatepwdform.usernewpwd2 !== '') {
          this.$refs.updatepwdform.validateField('usernewpwd2')
        }
        callback()
      }
    }
    var validatenewpwd2 = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请再次输入新密码!'))
      } else if (value !== this.updatepwdform.usernewpwd) {
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
            validator: validateoldpwd,
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
            validator: validatenewpwd,
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
            validator: validatenewpwd2,
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
    submitForm(updatepwdform) {
      this.$refs[updatepwdform].validate(valid => {
        if (valid) {
          console.log('update success')
        } else {
          console.log('update err')
        }
      })
      this.$refs[updatepwdform].resetFields()
    }
  }
}
</script>
