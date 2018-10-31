<template>
  <div id="ncc-interaction">
    <el-form
      ref="commentform"
      :model="commentform"
    >
      <el-input
        :autosize="{ minRows: 2, maxRows: 4}"
        v-model="commentform.commenttextarea"
        prop="commenttextarea"
        type="textarea"
        placeholder="请输入评论内容"
        class="mgb10"
      />
      <el-button
        type="success"
        plain
        @click="submitForm('commentform')"
      >
        提交
      </el-button>
    </el-form>
    <el-card
      v-if="comments.length > 0"
      shadow="hover"
    >
      <div
        v-for="comment in comments"
        :key="comment.id"
        index="index"
        class="comment pdt10"
      >
        <img
          :src="comment.owner.avatarUrl"
          alt=""
          class="wh30 round vertical-middle"
        >
        <span>
          {{ comment.owner.username }}
          <span v-if="comment.replyTo != null">
            回复 {{ comment.replyTo.owner.username }}：
          </span>
        </span>
        <span class="fr">{{ comment.utcCreated | formatDate }}</span>
        <p
          class="pointer mgt10"
          @click="showreplyInput(comment)"
        >
          {{ comment.text }}
        </p>
        <el-form
          v-if="comment.show"
          ref="replyform"
          :model="replyform"
        >
          <el-input
            :autosize="{ minRows: 2, maxRows: 4}"
            v-model="replyform.replytextarea"
            prop="replytextarea"
            type="textarea"
            placeholder="请输入回复内容"
            class="mgb10"
          />
          <el-button
            type="success"
            plain
            class="mgb10"
            @click="submitreplyForm('replyform')"
          >
            提交
          </el-button>
        </el-form>
      </div>
    </el-card>
    <el-card
      v-else
      shadow="hover"
    >
      暂无评论，等你来评！
    </el-card>
  </div>
</template>

<script>
export default {
  filters: {
    formatDate(date) {
      let currentDate = new Date(date).toLocaleString()
      return currentDate
    }
  },
  props: {
    comments: {
      type: Array,
      default: () => {}
    },
    postId: {
      type: String,
      default: ''
    }
  },
  data() {
    return {
      commentform: {
        commenttextarea: ''
      },
      replyform: {
        replytextarea: ''
      },
      showed: null
    }
  },
  methods: {
    showreplyInput(comment) {
      if (this.showed) {
        this.showed.show = false
      }
      comment.show = !comment.show
      this.showed = comment
    },
    submitForm(commentform) {
      if (!this.$store.state.auth.user) {
        this.$router.push('/user/signin')
      } else {
        setTimeout(() => {
          this.$axios
            .$post(`v1/posts/${this.postId}/comments`, {
              owner: {
                Id: this.$store.state.auth.user.id,
                username: this.$store.state.auth.user.username,
                avatarUrl: this.$store.state.auth.user.avatarUrl,
                email: this.$store.state.auth.user.email
              },
              postId: this.postId,
              text: this.commentform.commenttextarea
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
    },
    submitreplyForm(commentform) {
      if (!this.$store.state.auth.user) {
        this.$router.push('/user/signin')
      } else {
        setTimeout(() => {
          this.$axios
            .$post(`v1/posts/${this.postId}/comments`, {
              owner: {
                id: this.$store.state.auth.user.id,
                username: this.$store.state.auth.user.username,
                avatarUrl: this.$store.state.auth.user.avatarUrl,
                email: this.$store.state.auth.user.email
              },
              replyTo: this.showed.id,
              postId: this.postId,
              text: this.replyform.replytextarea
            })
            .then(res => {
              if (res.code === 0) {
                this.replyform.replytextarea = ''
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
      }
    }
  }
}
</script>

<style scoped>
.comment {
  border-bottom: 1px dashed #797979;
}
</style>
