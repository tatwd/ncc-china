<template>
  <div id="ncc-topicnoreply">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>无人回复的话题</span>
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
  //     const noreply = await this.$axios.$get('')
  //     this.noreply = noreply
  //   }
  // },
}
</script>
