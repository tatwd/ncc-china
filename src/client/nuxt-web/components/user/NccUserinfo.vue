<template>
  <div id="ncc-userinfo">
    <el-card
      class="box-card"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / 用户信息</span>
      </div>
      <div>
        <div class="ava-name">
          <img
            src="~/static/test.jpg"
            alt=""
          >
          <label>ncc</label>
        </div>
        <nuxt-link to="/user/setting">
          <el-button
            type="warning"
            plain
          >
            更改信息
          </el-button>
        </nuxt-link>
      </div>
    </el-card>
  </div>
</template>

<style scoped>
#ncc-userinfo .ava-name {
  margin-bottom: 10px;
}
#ncc-userinfo .ava-name img {
  width: 30px;
  vertical-align: middle;
}
#ncc-userinfo .ava-name label {
  margin-left: 10px;
  vertical-align: middle;
}
#ncc-userinfo p {
  margin: 0;
}
</style>
