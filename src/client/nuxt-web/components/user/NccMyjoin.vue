<template>
  <div id="ncc-myjoin">
    <el-card
      class="box-card"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>我参与的话题</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
        class="text item"
      >
        <nuxt-link to="/user/usercenter">
          {{ '话题 ' + o }}
        </nuxt-link>
      </div>
    </el-card>
  </div>
</template>
