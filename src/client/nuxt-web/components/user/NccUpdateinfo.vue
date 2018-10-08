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
        <span><router-link to="/">主页</router-link> / <router-link to="/user/usercenter">用户中心</router-link> / 修改信息</span>
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
            label="电子邮箱"
            prop="useremail"
          >
            <el-input v-model="updateinfoform.useremail" />
          </el-form-item>
          <el-form-item
            label="个人网站"
            prop="usersite"
          >
            <el-input v-model="updateinfoform.usersite" />
          </el-form-item>
          <el-form-item
            label="所在地点"
            prop="userplace"
          >
            <el-input v-model="updateinfoform.userplace" />
          </el-form-item>
          <el-form-item
            label="微博"
            prop="userweibo"
          >
            <el-input v-model="updateinfoform.userweibo" />
          </el-form-item>
          <el-form-item
            label="github"
            prop="usergithub"
          >
            <el-input v-model="updateinfoform.usergithub" />
          </el-form-item>
          <el-form-item
            label="个性签名"
            prop="usersignature"
          >
            <el-input
              v-model="updateinfoform.usersignature"
              type="textarea"
            />
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
        useremail: '',
        usersite: '',
        userplace: '',
        userweibo: '',
        usergithub: '',
        usersignature: ''
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
            message: '请输入邮箱地址',
            trigger: 'blur'
          },
          {
            type: 'email',
            message: '请输入正确的邮箱地址',
            trigger: 'blur'
          }
        ],
        usersite: [
          {
            required: false,
            message: '请输入个人站点',
            trigger: 'blur'
          }
        ],
        userplace: [
          {
            required: false,
            message: '请输入地点',
            trigger: 'blur'
          }
        ],
        userweibo: [
          {
            required: false,
            message: '请输入微博',
            trigger: 'blur'
          }
        ],
        usergithub: [
          {
            required: false,
            message: '请输入github',
            trigger: 'blur'
          }
        ],
        usersignature: [
          {
            required: false,
            message: '请输入个性签名',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 30,
            message: '长度在 6 到 30 个字符',
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
