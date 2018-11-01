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
        <h2 class="fs16 mgt0">{{ post.title }}</h2>
        <span>发布于 {{ post.utcCreated | timeAgo }}前</span>
        <span>作者 {{ post.author.username }}</span>
        <!-- <span>{{ browsenum }} 次浏览</span> -->
      </div>
      <div v-html="post.htmlText" />
    </el-card>
    <ncc-interaction
      :post-id="post.id"
      :comments="comments"
      @change="getcomments"
    />
  </div>
</template>
<script>
import NccInteraction from '~/components/post/NccInteraction.vue'

export default {
  components: {
    NccInteraction
  },
  async asyncData({ app, params }) {
    let post = await app.$axios.$get(`v1/posts/${params.id}`)
    let comments = await app.$axios.$get(`v1/posts/${params.id}/comments`)
    comments.data = comments.data.map(item => {
      item.show = false
      return item
    })
    return {
      post: post.data,
      comments: comments.data
    }
  },
  methods: {
    getcomments() {
      this.$axios.$get(`v1/posts/${this.post.id}/comments`).then(res => {
        if (res.code == 0) {
          this.comments = res.data.map(item => {
            item.show = false
            return item
          })
        }
      })
    }
  }
}
</script>

<style scoped>
h2 {
  color: #1a1a1a;
}
span {
  margin-right: 40px;
  color: #797979;
}
</style>
