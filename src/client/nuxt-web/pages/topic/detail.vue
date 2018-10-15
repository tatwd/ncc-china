<template>
  <div id="topic-detail">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <h2>{{ title }}</h2>
        <span>发布于 {{ time }}</span>
        <span>作者 {{ author }}</span>
        <span>{{ browsenum }} 次浏览</span>
      </div>
      <div>
        {{ content }}
      </div>
    </el-card>
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
      />
      <el-button
        type="success"
        plain
        @click="subForm('commentform')"
      >
        提交
      </el-button>
    </el-form>
    <ncc-interaction />
  </div>
</template>
<script>
import NccInteraction from '~/components/topic/NccInteraction.vue'

export default {
  components: {
    NccInteraction
  },
  data() {
    return {
      commentform: {
        commenttextarea: ''
      },
      title: '45',
      time: '4545',
      author: 'ds',
      browsenum: '44',
      content: 'kjhgfhjlkj'
    }
  },
  methods: {
    submitForm(commentform) {
      console.log('success')
      this.$refs[commentform].resetFields()
    }
  }
}
</script>

<style scoped>
#topic-detail h2 {
  color: #1a1a1a;
  font-size: 24px;
  font-weight: 600;
}
#topic-detail span {
  margin-right: 40px;
  color: #797979;
}
#topic-detail .el-form {
  margin: 10px;
}
#topic-detail .el-textarea {
  margin-bottom: 10px;
}
</style>
