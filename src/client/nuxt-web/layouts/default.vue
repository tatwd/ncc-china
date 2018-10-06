<template>
  <div class="layout-default">
    <el-container>
      <el-header height="auto">
        <ncc-header />
      </el-header>
      <nuxt/>
      <el-footer height="auto">
        <ncc-footer />
      </el-footer>
    </el-container>
    <ncc-backtop />
  </div>
</template>

<script>
import NccHeader from '~/components/shared/NccHeader.vue'
import NccFooter from '~/components/shared/NccFooter.vue'
import NccBacktop from '~/components/shared/NccBacktop.vue'

export default {
  components: {
    NccHeader,
    NccFooter,
    NccBacktop
  }
}
</script>

<style>
</style>
