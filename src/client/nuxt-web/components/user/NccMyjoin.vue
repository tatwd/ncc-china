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
        <router-link to="/user/usercenter">
          {{ '话题 ' + o }}
        </router-link>
      </div>
    </el-card>
  </div>
</template>
