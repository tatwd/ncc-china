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
        v-for="o in 4"
        :key="o"
      >
        <nuxt-link to="/">
          {{ '话题 ' + o }}
        </nuxt-link>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  // mounted: {
  //   async fetchUserinfo() {
  //     const hottopic = await this.$axios.$get('')
  //     this.hottopic = hottopic
  //   }
  // },
}
</script>
