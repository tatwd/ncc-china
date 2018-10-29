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
        <span>发布于 {{ post.utcCreated }}</span>
        <span>作者 {{ post.author.username }}</span>
        <!-- <span>{{ browsenum }} 次浏览</span> -->
      </div>
      <div>
        {{ post.htmlText }}
      </div>
    </el-card>
    <ncc-comment />
    <ncc-interaction />
  </div>
</template>
<script>
import NccComment from '~/components/topic/NccComment.vue'
import NccInteraction from '~/components/topic/NccInteraction.vue'

export default {
  components: {
    NccComment,
    NccInteraction
  },
  data() {
    return {
      title: '45',
      time: '4545',
      author: 'ds',
      browsenum: '44',
      content: 'kjhgfhjlkj'
    }
  },
  asyncData({ app, params, redirect }) {
    return app.$axios
      .$get(`v1/posts?id=${params.id}`)
      .then(res => {
        console.log(res)
        if (res.code == 0) {
          return { post: res.data }
        }
      })
      .catch(err => {
        redirect('/')
      })
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
