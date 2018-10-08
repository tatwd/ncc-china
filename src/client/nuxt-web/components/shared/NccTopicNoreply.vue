<template>
  <div id="ncc-topicnoreply">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>无人回复的话题</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
        class="text item"
      >
        <router-link to="/">
          {{ '话题 ' + o }}
        </router-link>
      </div>
    </el-card>
  </div>
</template>

<script>
</script>

<style>
</style>
