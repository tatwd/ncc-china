<template>
  <div class="layout-default">
    <el-container>
      <el-header height="auto">
        <ncc-header/>
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
  },
  mounted() {
    // if (!this.$store.state.auth) {
    //   const auth = {
    //     user_name: localStorage.getItem('currentUser_name'),
    //     user_token: localStorage.getItem('currentUser_token')
    //   }
    //   this.$store.commit('setUser', auth)
    // }
  }
}
</script>

<style>
</style>
