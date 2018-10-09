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
        :sm="4"
        :md="4"
        :lg="4"
        :xl="4"
      >
        <el-menu
          :router="true"
          mode="horizontal"
          background-color="#682079"
          text-color="#fff"
          active-text-color="#fff"
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
      <el-col
        :xs="24"
        :sm="6"
        :md="6"
        :lg="6"
        :xl="6"
      >
        <el-input
          :clearable="true"
          prefix-icon="el-icon-search"
          placeholder="Search"
        />
      </el-col>
      <el-col
        :xs="24"
        :sm="10"
        :md="10"
        :lg="10"
        :xl="10"
      >
        <el-menu
          v-if="login"
          :router="true"
          mode="horizontal"
          background-color="#682079"
          text-color="#fff"
          active-text-color="#fff"
          class="menu-right"
        >
          <el-menu-item
            route="topic/create"
            index="1"
          >
            <i class="el-icon-edit" />
          </el-menu-item>
          <el-menu-item
            route="/user/message"
            index="2"
          >
            <el-badge
              :value="3"
              :max="99"
              class="item"
            >
              <i class="el-icon-message" />
            </el-badge>
          </el-menu-item>
          <el-submenu index="3">
            <template slot="title">
              <img
                src="~/static/test.jpg"
                alt=""
              >
            </template>
            <el-menu-item
              route="/user"
              index="3-1"
            >
              <i class="el-icon-menu"> 我的主页</i>
            </el-menu-item>
            <el-menu-item
              route="/user/setting"
              index="3-2"
            >
              <i class="el-icon-setting"> 设置</i>
            </el-menu-item>
            <el-menu-item
              index="/"
            >
              <i class="el-icon-back"> 退出</i>
            </el-menu-item>
          </el-submenu>
        </el-menu>
        <el-menu
          v-if="!login"
          :router="true"
          mode="horizontal"
          background-color="#682079"
          text-color="#fff"
          active-text-color="#fff"
          class="menu-right"
        >
          <el-menu-item
            route="/user/signin"
            index="signin"
          >
            登录
          </el-menu-item>
          <el-menu-item
            route="/user/signup"
            index="signup"
          >
            注册
          </el-menu-item>
        </el-menu>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  data() {
    return {
      login: false
    }
  },
  computed: {
    navs() {
      return [
        {
          title: '首页',
          to: '/'
        },
        {
          title: '关于',
          to: '/about'
        }
      ]
    }
  }
}
</script>

<style>
#ncc-header {
  background-color: #682079;
}
#ncc-header .ncc-logo {
  position: relative;
  padding: 0 10px;
  width: 156px;
  height: 60px;
  color: #fff;
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
#ncc-header .el-menu--horizontal,
#ncc-header .el-menu--horizontal li,
#ncc-header .el-menu--horizontal > .el-submenu.is-active .el-submenu__title {
  border-bottom: none;
}
#ncc-header .el-input {
  margin-top: 10px;
  border: 0;
}
#ncc-header .el-input__inner {
  border: 0;
  border-radius: 20px;
  background-color: #e9e9e9;
}
#ncc-header .el-input__inner:hover {
  animation: change-color;
  animation-duration: 2s;
  animation-fill-mode: forwards;
}
@keyframes change-color {
  0% {
    background-color: #e9e9e9;
  }
  100% {
    background-color: #fff;
  }
}
#ncc-header .menu-right {
  float: right;
}
#ncc-header .el-menu-item {
  color: #fff;
}
#ncc-header .el-badge__content.is-fixed {
  top: 20px;
}
#ncc-header img {
  width: 30px;
  height: 30px;
  border-radius: 50%;
}
#ncc-header i {
  color: #fff;
}
</style>
