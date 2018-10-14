<template>
  <div id="usercenter">
    <el-container class="content ncc-container">
      <el-main>
        <ncc-unread />
        <ncc-allmessage />
      </el-main>
      <el-aside width="340px">
        <ncc-slider />
      </el-aside>
    </el-container>
  </div>
</template>

<script>
import NccUnread from '~/components/user/NccUnread.vue'
import NccAllmessage from '~/components/user/NccAllmessage.vue'
import NccSlider from '~/components/shared/NccSlider.vue'

export default {
  components: {
    NccUnread,
    NccAllmessage,
    NccSlider
  }
}
</script>
