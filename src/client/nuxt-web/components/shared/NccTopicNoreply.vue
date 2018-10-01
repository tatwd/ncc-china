<template>
  <div id="dnc-topicnoreply">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div slot="header" class="clearfix">
        <span>无人回复的话题</span>
      </div>
      <div v-for="o in 4" :key="o" class="text item">
        {{'话题 ' + o }}
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  
}
</script>

<style>
  
</style>

