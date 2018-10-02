<template>
  <div
    id="ncc-footer"
    class="ncc-container"
  >
    <el-row>
      <span>RSS</span> | <span>源码地址</span>
      <p>服务器搭建在，存储赞助商为</p>
      <p>声明：内容均来自于网络，如有侵权请联系删除</p>
    </el-row>
    <ncc-backtop />
  </div>
</template>

<script>
import NccBacktop from '~/components/shared/NccBackTop.vue'

export default {
  components: {
    NccBacktop
  }
}
</script>

<style>
#ncc-footer p {
  margin: 10px 0;
}
</style>
