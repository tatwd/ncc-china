<template>
  <div id="ncc-unread">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / 未读消息</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
      >
        <nuxt-link to="/">
          {{ '消息 ' + o }}
        </nuxt-link>
      </div>
    </el-card>
  </div>
</template>
