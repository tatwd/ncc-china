<template>
  <div id="usercenter">
    <ncc-myinfo :myinfo="myinfo"/>
    <ncc-mycreate :posts="posts" />
    <ncc-myjoin :comments="comments"/>
  </div>
</template>

<script>
import NccMyinfo from '~/components/user/NccMyinfo.vue'
import NccMycreate from '~/components/user/NccMycreate.vue'
import NccMyjoin from '~/components/user/NccMyjoin.vue'

export default {
  middleware: 'unauth',
  components: {
    NccMyinfo,
    NccMycreate,
    NccMyjoin
  },
  async asyncData({ app }) {
    let myinfo = await app.$axios.$get('v1/user')
    let posts = await app.$axios.$get('v1/user/posts')
    let comments = await app.$axios.$get('v1/comments')
    return {
      myinfo: myinfo.data,
      posts: posts.data,
      comments: comments.data
    }
  }
}
</script>
