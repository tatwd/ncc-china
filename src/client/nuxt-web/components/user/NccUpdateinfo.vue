<template>
  <div id="ncc-updateinfo">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / <nuxt-link to="/user">用户中心</nuxt-link> / 修改信息</span>
      </div>
      <div>
        <el-form
          ref="updateinfoform"
          :model="updateinfoform"
          :rules="rules"
          label-width="100px"
        >
          <el-form-item
            label="用户名"
            prop="username"
          >
            <el-input v-model="updateinfoform.username" />
          </el-form-item>
          <el-form-item
            label="性别"
            prop="gender"
          >
            <el-radio-group v-model="updateinfoform.gender">
              <el-radio :label="0">未知</el-radio>
              <el-radio :label="1">男</el-radio>
              <el-radio :label="2">女</el-radio>
            </el-radio-group>
          </el-form-item>
          <el-form-item>
            <el-button
              type="success"
              plain
              @click="submitForm('updateinfoform')"
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
    return {
      updateinfoform: {
        username: '',
        gender: 0
      },
      rules: {
        username: [
          {
            required: true,
            message: '请输入用户名',
            trigger: 'blur'
          }
        ]
      }
    }
  },
  methods: {
    submitForm(updateinfoform) {
      this.$refs[updateinfoform].validate(valid => {
        if (valid) {
          console.log('update success')
        } else {
          console.log('update err')
        }
      })
      this.$refs[updateinfoform].resetFields()
    }
  }
}
</script>
