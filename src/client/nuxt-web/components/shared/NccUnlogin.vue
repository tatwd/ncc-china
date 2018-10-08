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
            登录
          </router-link>
          或
          <router-link to="/user/signup">
            注册
          </router-link>
          ，也可以
        </p>
        <el-button
          type="primary"
          plain
        >
          通过 GitHub 登录
        </el-button>
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
