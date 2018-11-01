<template>
  <div id="usercenter">
    <ncc-userinfo />
    <ncc-mycreate />
    <ncc-myjoin
      :comments="comments"
    />
  </div>
</template>

<script>
import NccUserinfo from '~/components/user/NccUserinfo.vue'
import NccMycreate from '~/components/user/NccMycreate.vue'
import NccMyjoin from '~/components/user/NccMyjoin.vue'

export default {
  middleware: 'unauth',
  components: {
    NccUserinfo,
    NccMycreate,
    NccMyjoin
  },
  async asyncData({ app }) {
    let comments = await app.$axios.$get('v1/comments')
    return {
      comments: comments.data
    }
  }
}
</script>
