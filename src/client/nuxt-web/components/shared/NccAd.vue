<template>
  <div id="ncc-ad">
    <el-card shadow="hover">
      <div
        v-for="(ad, index) in ads"
        :key="index"
      >
        <img
          :src="ad.src"
          :alt="ad.alt"
        >
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  computed: {
    ads() {
      return [
        {
          src: require('../../static/ad.png'),
          alt: '广告赞助一'
        },
        {
          src: require('../../static/ad.png'),
          alt: '广告赞助二'
        },
        {
          src: require('../../static/ad.png'),
          alt: '广告赞助三'
        }
      ]
    }
  }
}
</script>

<style scoped>
#ncc-ad img {
  width: 100%;
  margin-bottom: 10px;
}
#ncc-ad img:last-child {
  margin-bottom: 0;
}
</style>
