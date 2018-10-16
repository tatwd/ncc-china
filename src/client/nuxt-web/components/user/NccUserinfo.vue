<template>
  <div id="ncc-userinfo">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / 用户信息</span>
      </div>
      <div class="ava-name">
        <img
          src="~/static/test.jpg"
          alt=""
        >
        <label>ncc</label>
      </div>
      <div class="userid">
        <span>用户ID：</span>
        <label>121</label>
      </div>
      <div class="gender">
        <span>性别：</span>
        <label>未知</label>
      </div>
      <div class="createtime">
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
.ava-name,
.userid,
.gender,
.createtime {
  margin-bottom: 10px;
}
#ncc-userinfo .ava-name img {
  width: 50px;
  height: 50px;
  vertical-align: middle;
}
#ncc-userinfo label {
  margin-left: 20px;
  vertical-align: middle;
}
#ncc-userinfo p {
  margin: 0;
}
</style>
