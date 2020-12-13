<template>
  <div id="ncc-myinfo">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / 我的信息</span>
      </div>
      <div class="ava-name mgb10">
        <img
          :src="myinfo.avatarUrl"
          alt=""
          class="wh50 round vertical-middle"
        >
        <label class="fs16">{{ myinfo.username }}</label>
      </div>
      <div class="userid mgb10">
        <span>用户ID：</span>
        <label>{{ myinfo.id }}</label>
      </div>
      <div class="nickname mgb10">
        <span>用户昵称：</span>
        <label>{{ myinfo.nickname }}</label>
      </div>
      <div class="email mgb10">
        <span>用户邮箱：</span>
        <label>{{ myinfo.email }}</label>
      </div>
      <div class="gender mgb10">
        <span>性别：</span>
        <label>{{ sex[myinfo.gender] }}</label>
      </div>
      <div class="gender mgb10">
        <span>个人简介：</span>
        <label>{{ myinfo.bio }}</label>
      </div>
      <div class="createtime mgb10">
        <span>注册时间：</span>
        <label>{{ new Date(myinfo.utcCreated).toDateString() }}</label>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  props: {
    myinfo: {
      type: Object,
      default: null
    }
  },
  data() {
    return {
      sex: ['未知', '男', '女']
    }
  }
}
</script>

<style scoped>
label {
  margin-left: 20px;
}
</style>
