<template>
  <div
    id="ncc-header"
    class="ncc-container"
  >
    <el-row>
      <el-col
        :xs="24"
        :sm="4"
        :md="4"
        :lg="4"
        :xl="4"
      >
        <!-- <img src="../../static/images/logo.png" /> -->
        <div class="ncc-logo">
          <span class="logo1">.NET</span>
          <span class="logo2">C</span>
          <span class="logo1">re</span>
          <div class="logo-cir" />
        </div>
      </el-col>
      <el-col
        :xs="24"
        :sm="6"
        :md="6"
        :lg="6"
        :xl="6"
      >
        <el-input
          :clearable="true"
          placeholder="Search"
        />
      </el-col>
      <el-col
        :xs="24"
        :sm="14"
        :md="14"
        :lg="14"
        :xl="14"
      >
        <el-menu
          :router="true"
          mode="horizontal"
          background-color="#aca0c7"
          text-color="#682079"
          active-text-color="#682079"
        >
          <el-menu-item
            v-for="(nav, index) in navs"
            :key="index"
            :route="nav.to"
            index="index"
          >
            {{ nav.title }}
          </el-menu-item>
        </el-menu>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  computed: {
    navs() {
      return [
        { title: '首页', to: '/' },
        { title: '微信公众号', to: '/' },
        { title: '参考资料', to: '/' },
        { title: 'API', to: '/' },
        { title: '关于', to: '/' },
        { title: '注册', to: '/user/signup' },
        { title: '登录', to: '/user/signin' }
      ]
    }
  }
}
</script>

<style>
#ncc-header {
  /* background-color: #682079; */
  /* background-color: #ede8f8; */
  background-color: #aca0c7;
}
#ncc-header .ncc-logo {
  position: relative;
  padding: 0 10px;
  width: 156px;
  height: 60px;
  color: #682079;
}
#ncc-header .ncc-logo .logo1 {
  font-size: 30px;
  vertical-align: middle;
}
#ncc-header .ncc-logo .logo2 {
  margin-left: 10px;
  font-size: 44px;
  vertical-align: middle;
}
#ncc-header .ncc-logo .logo-cir {
  position: absolute;
  top: 25px;
  left: 100px;
  width: 12px;
  height: 12px;
  border-radius: 50%;
  background-color: #34d0ff;
}
#ncc-header .el-row img {
  height: 56px;
}
#ncc-header .el-menu--horizontal {
  border-bottom: none;
}
#ncc-header .el-menu--horizontal li {
  border-bottom: none;
}
#dnc-header .el-menu {
  float: right;
}
#ncc-header .el-input {
  margin-top: 10px;
  border: 0;
}
#ncc-header .el-input__inner {
  border: 0;
  border-radius: 20px;
  border: 1px solid #e1e1e1;
  background-color: #efe8e8;
}
#ncc-header .el-input__inner:hover {
  animation: change-color;
  animation-duration: 2s;
  animation-fill-mode: forwards;
}
@keyframes change-color {
  0% {
    background-color: #efe8e8;
  }
  100% {
    background-color: #fff;
  }
}
</style>
