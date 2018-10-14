<template>
  <div id="setting">
    <el-container class="content ncc-container">
      <el-main>
        <ncc-updateinfo />
        <ncc-updatepwd />
      </el-main>
      <el-aside width="340px">
        <ncc-slider />
      </el-aside>
    </el-container>
  </div>
</template>

<script>
import NccUpdateinfo from '~/components/user/NccUpdateinfo.vue'
import NccUpdatepwd from '~/components/user/NccUpdatepwd.vue'
import NccSlider from '~/components/shared/NccSlider.vue'

export default {
  components: {
    NccUpdateinfo,
    NccUpdatepwd,
    NccSlider
  }
}
</script>
