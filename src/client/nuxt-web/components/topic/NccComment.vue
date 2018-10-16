<template>
  <div id="ncc-comment">
    <el-form
      :model="commentform"
      rel="commentform"
    >
      <el-input
        :autosize="{ minRows: 2, maxRows: 4}"
        v-model="commentform.commenttextarea"
        prop="commenttextarea"
        type="textarea"
        placeholder="请输入评论内容"
        class="mb10"
      />
      <el-button
        type="success"
        plain
        @click="subForm('commentform')"
      >
        提交
      </el-button>
    </el-form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      commentform: {
        commenttextarea: ''
      }
    }
  },
  methods: {
    submitForm(commentform) {
      setTimeout(() => {
        this.$axios
          .$post('', {
            commentcontent: this.commentform.commenttextarea
          })
          .then(res => {
            if (res.code === 0) {
              this.$message({
                showClose: true,
                message: '评论成功！',
                type: 'success'
              })
            } else {
              this.$message({
                showClose: true,
                message: '评论失败，请重试！',
                type: 'error'
              })
            }
          })
      }, 500)
      this.$refs[commentform].resetFields()
    }
  }
}
</script>
