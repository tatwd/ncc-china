<template>
  <div id="ncc-unread">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span><router-link to="/">主页</router-link> / 未读消息</span>
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
