<template>
  <div id="ncc-userinfo">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / 用户信息</span>
      </div>
      <div class="ava-name mgb10">
        <img
          :src="avatarUrl"
          alt=""
          class="wh50 round vertical-middle"
        >
        <label class="fs16">{{ username }}</label>
      </div>
      <div class="userid mgb10">
        <span>用户ID：</span>
        <label>{{ id }}</label>
      </div>
      <div class="gender mgb10">
        <span>性别：</span>
        <label>{{ gender }}</label>
      </div>
      <div class="createtime mgb10">
        <span>注册时间：</span>
        <label>{{ utcCreate }}</label>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  data() {
    let {
      id,
      avatarUrl,
      username,
      email,
      gender,
      utcCreate
    } = this.$store.state.auth.user
    return {
      id,
      avatarUrl,
      username,
      email,
      gender,
      utcCreate
    }
  }
}
</script>

<style scoped>
label {
  margin-left: 20px;
}
</style>
