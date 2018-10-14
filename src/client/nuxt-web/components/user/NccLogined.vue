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
        <nuxt-link to="/user">
          <div class="ava-name">
            <img
              src="~/static/test.jpg"
              alt=""
            >
            <label>ncc</label>
          </div>
        </nuxt-link>
        <span>积分：</span>
        <label>0</label>
        <p>123</p>
        <nuxt-link to="/user/message">
          <el-button
            type="primary"
            plain
          >
            未读消息
          </el-button>
        </nuxt-link>
        <el-button
          type="warning"
          plain
          @click="signout"
        >
          注销登录
        </el-button>
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
  },
  methods: {
    signout() {
      console.log('signout')
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
</style>
