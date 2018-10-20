<template>
  <div id="ncc-header">
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
            class="vertical-middle"
          >
        </h1>
      </el-col>
      <el-col :sm="13">
        <nuxt-link
          v-for="(nav, index) in navs"
          :key="index"
          :to="nav.to"
          class="white nav-link"
        >
          <span class="white">{{ nav.title }}</span>
        </nuxt-link>
      </el-col>
      <el-col :sm="6">
        <ncc-flex
          v-if="!isLogin"
          justify="end"
        >
          <nuxt-link
            to="/user/message"
            class="white nav-link"
          >
            <el-badge
              :value="3"
              :max="99"
              class="msg-num"
            >
              <i class="el-icon-message fs16 white" />
            </el-badge>
          </nuxt-link>

          <el-dropdown>
            <span class="white no-outline pointer">
              <img
                alt="我"
                src="/test.jpg"
                height="32"
                class="vertical-moddle round"
              >
              <i class="el-icon-arrow-down el-icon--right"/>
            </span>
            <el-dropdown-menu slot="dropdown">
              <nuxt-link to="/user">
                <el-dropdown-item>
                  我的主页
                </el-dropdown-item>
              </nuxt-link>
              <nuxt-link to="/user/setting">
                <el-dropdown-item>
                  设置
                </el-dropdown-item>
              </nuxt-link>
              <el-dropdown-item
                divided
                @click="loginout"
              >
                退出
              </el-dropdown-item>
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
              class="white transparent pdlr15"
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
          title: 'Wiki',
          to: '/wiki'
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
.logo {
  margin: 0;
  padding: 15px 0;
}
.nav-link {
  padding-left: 15px;
  padding-right: 15px;
}
.msg-num {
  right: 20px;
}
.transparent:hover {
  color: #eee;
}
</style>
