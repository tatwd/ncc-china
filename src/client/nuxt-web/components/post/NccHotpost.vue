<template>
  <div id="ncc-hotpost">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>热门帖子</span>
      </div>
      <div
        v-for="hotpost in hotposts"
        :key="hotpost.id"
      >
        <nuxt-link :to="`/post/`+hotpost.id">
          {{ hotpost.title }}
        </nuxt-link>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      hotposts: []
    }
  },
  created() {
    this.$axios.$get('v1/posts?type=hot').then(res => {
      if (res.code == 0) {
        this.hotposts = res.data
      }
    })
  }
}
</script>
