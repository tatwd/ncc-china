<template>
  <div id="ncc-unlogin">
    <el-card
      v-if="unlogin"
      class="box-card"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>.NET Core 专业中文社区</span>
      </div>
      <div>
        <p>
          您可以
          <router-link to="/user/signin">
            <span>登录</span>
          </router-link>
          或
          <router-link to="/user/signup">
            <span>注册</span>
          </router-link>
          ，也可以
        </p>
        <el-button type="primary">通过 GitHub 登录</el-button>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      unlogin: true
    }
  }
}
</script>

<style>
#ncc-unlogin p {
  margin-bottom: 20px;
}
#ncc-unlogin span {
  color: #682079;
}
</style>
