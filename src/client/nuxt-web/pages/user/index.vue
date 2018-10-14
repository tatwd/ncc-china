<template>
  <div id="usercenter">
    <el-container class="content ncc-container">
      <el-main>
        <ncc-userinfo />
        <ncc-mycreate />
        <ncc-myjoin />
      </el-main>
      <el-aside width="340px">
        <ncc-slider />
      </el-aside>
    </el-container>
  </div>
</template>

<script>
import NccUserinfo from '~/components/user/NccUserinfo.vue'
import NccMycreate from '~/components/user/NccMycreate.vue'
import NccMyjoin from '~/components/user/NccMyjoin.vue'
import NccSlider from '~/components/shared/NccSlider.vue'

export default {
  components: {
    NccUserinfo,
    NccMycreate,
    NccMyjoin,
    NccSlider
  }
}
</script>
