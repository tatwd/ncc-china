<template>
  <div id="ncc-allmessage">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>全部消息</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
      >
        <nuxt-link to="/">
          {{ '消息 ' + o }}
        </nuxt-link>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  // mounted: {
  //   async fetchUserinfo() {
  //     const allmessage = await this.$axios.$get('')
  //     this.allmessage = allmessage
  //   }
  // },
}
</script>
