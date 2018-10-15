<template>
  <div id="ncc-hottopic">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>热门话题</span>
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
