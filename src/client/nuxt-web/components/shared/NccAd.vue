<template>
  <div id="dnc-ad">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div v-for="o in 4" :key="o" class="text item">
        {{'广告赞助位 ' + o }}
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
