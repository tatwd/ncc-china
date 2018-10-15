<template>
  <div id="">
    <el-row
      type="flex"
      align="middle"
    >
      <el-col :sm="5">
        <!-- <img src="../../static/images/logo.png" /> -->
        <h1 style="margin: 0; padding: 15px 0;">
          <span>.NET Core 社区</span>
          <img
            height="32"
            style="vertical-align:middle"
            src="https://assets-cdn.github.com/images/icons/emoji/unicode/1f1e8-1f1f3.png"
            alt="中国"
          >
        </h1>
      </el-col>

      <el-col :sm="13">
        <nuxt-link
          v-for="(nav, index) in navs"
          :key="index"
          :to="nav.to"
          class="text-white nav-link"
        >
          {{ nav.title }}
        </nuxt-link>
      </el-col>

      <el-col :sm="6">
        <ncc-flex
          v-if="isLogin"
          justify="end"
        >
          <nuxt-link
            to="/"
            class="text-white nav-link"
          >
            <el-badge
              :value="3"
              :max="99"
            >
              <i class="el-icon-message fs16" />
            </el-badge>
          </nuxt-link>

          <el-dropdown>
            <span class="text-white no-outline pointer">
              <img
                alt="我"
                src="/test.jpg"
                height="32"
                class="vertical-moddle round"
              >
              <i class="el-icon-arrow-down el-icon--right"/>
            </span>
            <el-dropdown-menu slot="dropdown">
              <el-dropdown-item>我的主页</el-dropdown-item>
              <el-dropdown-item>设置</el-dropdown-item>
              <el-dropdown-item divided>退出</el-dropdown-item>
            </el-dropdown-menu>
          </el-dropdown>
        </ncc-flex>
        <ncc-flex
          v-else
          justify="end"
        >
          <el-button
            type="text"
            size="small"
            class="text-white transparent"
          >
            登录
          </el-button>
          <el-button
            type="success"
            size="small"
          >
            注册
          </el-button>
        </ncc-flex>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import NccFlex from './NccFlex.vue'

export default {
  components: {
    NccFlex
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
    },
    isLogin() {
      let _isLogin = this.$store.state.auth.token
      return _isLogin
    }
  },
  methods: {
    loginout() {
      this.$store.state.auth.token = null
    }
  }
}
</script>

<style scoped>
.nav-link {
  padding-left: 15px;
  padding-right: 15px;
}

.fs16 {
  font-size: 24px;
  line-height: 1.5;
}

.transparent:hover {
  color: #eee;
}

/* #ncc-header {
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
} */
</style>
