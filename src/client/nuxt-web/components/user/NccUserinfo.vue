<template>
  <div id="ncc-userinfo">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / 用户信息</span>
      </div>
      <div class="ava-name mb10">
        <img
          src="~/static/test.jpg"
          alt=""
          class="wh50 round vertical-middle"
        >
        <label class="fs16">ncc</label>
      </div>
      <div class="userid mb10">
        <span>用户ID：</span>
        <label>121</label>
      </div>
      <div class="gender mb10">
        <span>性别：</span>
        <label>未知</label>
      </div>
      <div class="createtime mb10">
        <span>注册时间：</span>
        <label>2018-10-15</label>
      </div>
      <nuxt-link to="/user/setting">
        <el-button
          type="warning"
          plain
        >
          更改信息
        </el-button>
      </nuxt-link>
    </el-card>
  </div>
</template>

<style scoped>
label {
  margin-left: 20px;
}
</style>
