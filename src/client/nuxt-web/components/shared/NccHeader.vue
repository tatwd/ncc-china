<template>
  <div id="">
    <el-row
      type="flex"
      align="middle"
    >
      <el-col :sm="5">
        <h1 class="logo">
          <span>.NET Core 社区</span>
          <img
            height="32"
            src="https://assets-cdn.github.com/images/icons/emoji/unicode/1f1e8-1f1f3.png"
            alt="中国"
            class="vertical-moddle"
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
          <nuxt-link to="/user/signin">
            <el-button
              type="text"
              size="small"
              class="text-white transparent pdlr15"
            >
              登录
            </el-button>
          </nuxt-link>
          <nuxt-link to="/user/signup">
            <el-button
              type="success"
              size="small"
            >
              注册
            </el-button>
          </nuxt-link>
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
        },
        {
          title: 'Wiki',
          to: '/wiki'
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
.logo {
  margin: 0;
  padding: 15px 0;
}
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
</style>
