<template>
  <div id="ncc-updateinfo">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / <nuxt-link to="/user">用户中心</nuxt-link> / 修改信息</span>
      </div>
      <el-form
        ref="updateinfoform"
        :model="currentuser"
        :rules="rules"
        label-width="100px"
      >
        <el-form-item
          label="头像："
          prop="avatar"
        >
          <el-upload
            :show-file-list="false"
            :on-success="handleAvatarSuccess"
            :before-upload="beforeAvatarUpload"
            class="avatar-uploader"
            action="https://jsonplaceholder.typicode.com/posts/"
          >
            <img
              :src="currentuser.avatarUrl"
              alt=""
              class="avatar"
            >
          </el-upload>
        </el-form-item>
        <el-form-item
          label="昵称："
          prop="nickname"
        >
          <el-input v-model="currentuser.nickname" />
        </el-form-item>
        <el-form-item
          label="邮箱："
          prop="email"
        >
          <el-input v-model="currentuser.email" />
        </el-form-item>
        <el-form-item
          label="性别："
          prop="gender"
        >
          <el-radio-group v-model="currentuser.gender">
            <el-radio :label="1">男</el-radio>
            <el-radio :label="2">女</el-radio>
          </el-radio-group>
        </el-form-item>
        <el-form-item
          label="个人简介："
          prop="bio"
        >
          <el-input
            :autosize="{ minRows: 2, maxRows: 4}"
            v-model="currentuser.bio"
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
    </el-card>
  </div>
</template>

<script>
export default {
  props: {
    currentuser: {
      type: Object,
      default: null
    }
  },
  data() {
    return {
      rules: {
        nickname: [
          {
            required: true,
            message: '请输入用户昵称',
            trigger: 'blur'
          }
        ],
        email: [
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
        bio: [
          {
            required: false,
            message: '请输入用户个人简介',
            trigger: 'blur'
          },
          {
            min: 0,
            max: 140,
            message: '长度在 0 到 140 个字符',
            trigger: 'blur'
          }
        ]
      }
    }
  },
  methods: {
    handleAvatarSuccess(res, file) {
      this.avatar = URL.createObjectURL(file.raw)
    },
    beforeAvatarUpload(file) {
      const isJPG = file.type === 'image/jpeg'
      const isLt2M = file.size / 1024 / 1024 < 2

      if (!isJPG) {
        this.$message.error('上传头像图片只能是 JPG 格式!')
      }
      if (!isLt2M) {
        this.$message.error('上传头像图片大小不能超过 2MB!')
      }
      return isJPG && isLt2M
    },
    submitForm(updateinfoform) {
      this.$refs[updateinfoform].validate(valid => {
        if (valid) {
          let {
            avatarUrl,
            username,
            nickname,
            email,
            gender,
            bio
          } = this.currentuser
          setTimeout(() => {
            this.$axios
              .$post('v1/user', {
                username,
                avatarUrl,
                nickname,
                email,
                gender,
                bio
              })
              .then(res => {
                if (res.code === 0) {
                  this.$message({
                    showClose: true,
                    message: '信息修改成功！',
                    type: 'success'
                  })
                } else {
                  this.$message({
                    showClose: true,
                    message: '信息修改失败，请重试！',
                    type: 'error'
                  })
                }
              })
          }, 100)
        } else {
          this.$message({
            showClose: true,
            message: '请输入正确的用户信息！',
            type: 'error'
          })
          return false
        }
      })
    }
  }
}
</script>

<style>
.avatar-uploader .el-upload {
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  cursor: pointer;
  overflow: hidden;
}
.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}
.avatar {
  width: 178px;
  height: 178px;
  display: block;
}
</style>
