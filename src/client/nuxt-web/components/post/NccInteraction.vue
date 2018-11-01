<template>
  <div id="ncc-interaction">
    <el-form
      ref="commentform"
      :model="comment"
    >
      <el-input
        :autosize="{ minRows: 2, maxRows: 4}"
        v-model="comment.text"
        prop="commenttextarea"
        type="textarea"
        placeholder="请输入评论内容"
        class="mgb10"
      />
      <el-button
        type="success"
        plain
        @click="submitComment"
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
        <span class="fr">{{ comment.utcCreated | timeAgo }}前</span>
        <p
          class="pointer mgt10"
          @click="showreplyInput(comment)"
        >
          {{ comment.text }}
        </p>
        <el-form
          v-if="comment.show"
          ref="replyform"
          :model="reply"
        >
          <el-input
            :autosize="{ minRows: 2, maxRows: 4}"
            v-model="reply.text"
            prop="replytextarea"
            type="textarea"
            placeholder="请输入回复内容"
            class="mgb10"
          />
          <el-button
            type="success"
            plain
            class="mgb10"
            @click="submitReplyComment"
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
      showed: null,
      comment: {
        replyTo: null,
        postId: this.postId,
        text: ''
      },
      reply: {
        replyTo: null,
        postId: this.postId,
        text: ''
      }
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

    createComment(data, cb) {
      if (!this.$store.state.auth.user) {
        this.$router.push('/user/signin')
      } else {
        data.owner = {
          id: this.$store.state.auth.user.id,
          username: this.$store.state.auth.user.username,
          avatarUrl: this.$store.state.auth.user.avatarUrl,
          email: this.$store.state.auth.user.email
        }
        setTimeout(() => {
          this.$axios
            .$post(`v1/posts/${this.postId}/comments`, data)
            .then(res => {
              if (cb) cb(res)
            })
        }, 500)
      }
    },

    submitComment() {
      this.createComment(this.comment, res => {
        if (res.code === 0) {
          this.$emit('change')
          this.comment.text = ''
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
    },
    submitReplyComment() {
      this.reply.replyTo = this.showed.id
      this.createComment(this.reply, res => {
        if (res.code === 0) {
          this.$emit('change')
          this.reply.text = ''
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
    }
  }
}
</script>

<style scoped>
.comment {
  border-bottom: 1px dashed #797979;
}
</style>
