<template>
  <div id="ncc-hottopic">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>热门话题</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
      >
        <router-link to="/">
          {{ '话题 ' + o }}
        </router-link>
      </div>
    </el-card>
  </div>
</template>
