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
        v-for="(comment, index) in comments"
        :key="index"
        index="index"
      >
        <img
          :src="comment.owner.avatarUrl"
          alt=""
          class="wh30 round vertical-middle"
        >
        <span>{{ comment.owner.username }}</span>
        <span>{{ comment.utcCreated }}</span>
        <p @click="showreplyInput">{{ comment.text }}</p>
        <el-form
          v-show="showreply"
          ref="replyform"
          :model="replyform"
        >
          <el-input
            :autosize="{ minRows: 2, maxRows: 4}"
            v-model="replyform.replytextarea"
            prop="replytextarea"
            type="textarea"
            placeholder="请输入回复内容"
          />
          <el-button
            type="success"
            plain
            @click="submitForm('replyform')"
          >
            提交
          </el-button>
        </el-form>
        <div
          v-for="(reply, index) in replys"
          :key="index"
          index="index"
        >
          <img
            :src="reply.ava"
            alt=""
            class="wh30 round vertical-middle"
          >
          <span>{{ reply.name }}</span>
          <span>{{ reply.time }}</span>
          <p @click="showreply1Input">{{ reply.content }}</p>
          <el-form
            v-show="showreply1"
            ref="reply1form"
            :model="replyform"
          >
            <el-input
              :autosize="{ minRows: 2, maxRows: 4}"
              v-model="reply1form.reply1textarea"
              prop="reply1textarea"
              type="textarea"
              placeholder="请输入回复内容"
            />
            <el-button
              type="success"
              plain
              @click="submitForm('reply1form')"
            >
              提交
            </el-button>
          </el-form>
        </div>
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
      reply1form: {
        reply1textarea: ''
      },
      showreply: false,
      showreply1: false
    }
  },
  methods: {
    showreplyInput() {
      this.showreply = !this.showreply
    },
    showreply1Input() {
      this.showreply1 = !this.showreply1
    },
    submitForm(commentform) {
      if (this.$store.state.auth.user.id == null) {
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
    }
  }
}
</script>
