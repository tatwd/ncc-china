<template>
  <div id="about">
    <el-container class="content ncc-container">
      <el-main>
        <ncc-about />
      </el-main>
      <el-aside width="340px">
        <ncc-slider />
      </el-aside>
    </el-container>
  </div>
</template>

<script>
import NccAbout from '~/components/about/NccAbout.vue'
import NccSlider from '~/components/shared/NccSlider.vue'

export default {
  components: {
    NccAbout,
    NccSlider
  }
}
</script>
