<template>
  <div class="layout-default">
    <el-container>
      <el-header height="auto">
        <ncc-header />
      </el-header>
      <el-container class="ncc-container">
        <el-main>
          <nuxt/>
        </el-main>
        <el-aside width="340px">
          <ncc-slider />
        </el-aside>
      </el-container>
      <el-footer height="auto">
        <ncc-footer />
      </el-footer>
    </el-container>
    <ncc-backtop />
  </div>
</template>

<script>
import NccHeader from '~/components/shared/NccHeader.vue'
import NccSlider from '~/components/shared/NccSlider.vue'
import NccFooter from '~/components/shared/NccFooter.vue'
import NccBacktop from '~/components/shared/NccBacktop.vue'

export default {
  components: {
    NccHeader,
    NccSlider,
    NccFooter,
    NccBacktop
  }
}
</script>

<style>
</style>
