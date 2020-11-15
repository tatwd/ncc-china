<template>
  <div id="ncc-header">
    <el-row
      type="flex"
      align="middle"
    >
      <el-col :sm="5">
        <h1 class="logo">
          <nuxt-link
            to="/"
            class="text--white text:hover--white">
            <span>.NET 社区</span>
            <img
              height="32"
              src="/cn.png"
              alt=""
              class="vertical-middle"
            >
          </nuxt-link>
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
          v-if="isLogin"
          justify="end"
        >
          <!-- <nuxt-link
            to="/user/message"
            class="white nav-link"
          >
            <el-badge
              :value="0"
              :max="99"
              class="msg-num"
            >
            <i class="el-icon-message fs16 white" />
            </el-badge>
          </nuxt-link> -->

          <el-dropdown>
            <span class="white no-outline pointer">
              <img
                :src="this.$store.state.auth.user.avatarUrl"
                alt=""
                height="32"
                class="vertical-middle round"
              >
              <i class="el-icon-arrow-down el-icon--right" />
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
              <el-dropdown-item divided>
                <span @click="logout">退出</span>
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
const Cookie = process.client ? require('js-cookie') : undefined

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
      let auth = this.$store.state.auth
      return auth && auth.token
    }
  },
  methods: {
    logout() {
      //console.log(1)
      Cookie.remove('auth')
      // this.$router.push('/user/signin')
      window.location.href = '/user/signin'
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
