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
        <h2>{{ topic.title }}</h2>
        <span>发布与{{ topic.time }}</span>
        <span>作者{{ topic.author }}</span>
        <span>{{ topic.browsenum }}次浏览</span>
        <span>来自{{ topic.type }}</span>
      </div>
      <div>
        {{ topic.content }}
      </div>
    </el-card>
    <el-form
      :model="commentform"
      rel="commentform"
    >
      <el-input
        :autosize="{ minRows: 2, maxRows: 4}"
        v-model="commenttextarea"
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
      console.log('success')
      this.$refs[commentform].resetFields()
    }
  }
}
</script>
