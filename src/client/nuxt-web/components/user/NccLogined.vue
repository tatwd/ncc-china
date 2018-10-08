<template>
  <div id="ncc-logined">
    <el-card
      v-if="logined"
      class="box-card"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>个人信息</span>
      </div>
      <div>
        <router-link to="/user/usercenter">
          <div class="ava-name">
            <img
              src="~/static/test.jpg"
              alt=""
            >
            <label>ncc</label>
          </div>
        </router-link>
        <span>积分：</span>
        <label>0</label>
        <p>123</p>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      logined: true
    }
  }
}
</script>

<style scoped>
#ncc-logined .ava-name {
  margin-bottom: 10px;
}
#ncc-logined .ava-name img {
  width: 30px;
  vertical-align: middle;
}
#ncc-logined .ava-name label {
  margin-left: 10px;
  vertical-align: middle;
}
#ncc-logined p {
  margin: 0;
}
</style>
