<template>
  <div class="layout-default">
    <el-container>
      <el-header
        height="auto"
        style="padding: 0;"
        class="theme"
      >
        <el-row>
          <el-col
            :span="20"
            :offset="2"
          >
            <ncc-header/>
          </el-col>
        </el-row>
      </el-header>

      <el-row>
        <el-col
          :span="20"
          :offset="2"
        >
          <el-container>
            <el-main style="padding: 0;margin-right: 15px;">
              <nuxt/>
            </el-main>
            <el-aside width="340px">
              <ncc-slider />
            </el-aside>
          </el-container>
        </el-col>
      </el-row>

      <el-footer
        height="auto"
        class="theme"
      >
        <el-row>
          <el-col
            :span="20"
            :offset="2"
          >
            <ncc-footer />
          </el-col>
        </el-row>
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

<style scoped>
.theme {
  background-color: var(--main-color);
  color: #fff;
}
</style>
