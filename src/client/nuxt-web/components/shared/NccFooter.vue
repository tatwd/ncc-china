<template>
  <div id="dnc-footer">
    <el-row>
      <span>RSS</span> | <span>源码地址</span>
      <p>服务器搭建在，存储赞助商为</p>
      <p>声明：内容均来自于网络，如有侵权请联系删除</p>
    </el-row>
    <dnc-backtop />
  </div>
</template>

<script>
  import DncBacktop from '~/components/shared/DncBackTop.vue'

  export default {
    components: {
      DncBacktop
    }
  }
</script>

<style>
  #dnc-footer p {
    margin: 10px 0;
  }
</style>
