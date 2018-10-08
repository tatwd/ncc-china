<template>
  <div id="ncc-allmessage">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>全部消息</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
      >
        <router-link to="/">
          {{ '消息 ' + o }}
        </router-link>
      </div>
    </el-card>
  </div>
</template>
