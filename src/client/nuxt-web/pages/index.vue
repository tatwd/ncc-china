<template>
  <section id="app">
    <el-form
      ref="searchform"
      :model="searchform"
      class="mgt10"
    >
      <el-form-item prop="search">
        <el-input
          v-model="searchform.search"
          placeholder="请选择搜索内容"
          suffix-icon="el-icon-search"
          @keyup.enter.native="search"
        />
      </el-form-item>
    </el-form>
    <el-row
      type="flex"
      align="middle"
    >
      <el-col>
        <el-button
          v-for="(type, index) in types"
          :key="index"
          type="primary"
          size="small"
        >
          {{ type.title }}
        </el-button>
      </el-col>
    </el-row>
    <div
      v-for="post in posts"
      :key="post.id"
    >
      <el-card shadow="hover">
        <div class="topic-list">
          <img
            :src="post.author.avatarUrl"
            alt=""
            class="wh30 round vertical-middle"
          >
          <span class="topic-type mglr10 pdtb4 pdlr10 white pointer">
            {{ post.category.title }}
          </span>
          <nuxt-link :to="`/post/`+post.id">
            <span class="fs12">{{ post.title }}</span>
          </nuxt-link>
          <div class="mgtb15">
            <span
              v-for="(tag, index) in post.tags"
              :key="index"
              class="tag pdtb4 pdlr10 fs8 pointer"
            >
              # {{ tag }}
            </span>
          </div>
          <el-row
            type="flex"
            align="middle"
          >
            <el-col :sm="12">
              <span>
                <i class="el-icon-view"> {{ post.viewsCount }}</i>
              </span>
              <span class="mglr10">
                <i class="el-icon-edit-outline"> {{ post.commentsCount }}</i>
              </span>
            </el-col>
            <el-col :sm="12">
              <ncc-flex justify="end">
                <span class="mglr10">{{ post.utcCreated | timeAgo }}前</span>
              </ncc-flex>
            </el-col>
          </el-row>
        </div>
      </el-card>
    </div>
  </section>
</template>

<script>
import NccFlex from '~/components/shared/NccFlex.vue'

export default {
  components: {
    NccFlex
  },
  data() {
    return {
      searchform: {
        search: ''
      }
    }
  },
  computed: {
    types() {
      return [
        { title: '全部', to: '/' },
        { title: '关注', to: '/' },
        { title: '热榜', to: '/' }
      ]
    }
  },
  asyncData({ app }) {
    return app.$axios
      .$get('v1/posts', {
        params: {
          page: 1,
          limit: 10,
          category: 'test',
          desc: true
        }
      })
      .then(res => {
        console.log(res.data)
        if (res.code == 0) {
          return { posts: res.data }
        }
      })
      .catch(err => {
        console.log(err)
      })
  },
  methods: {
    search() {
      setTimeout(() => {
        this.$axios
          .$post('', {
            search: this.searchform.search
          })
          .then(res => {
            console.log(res)
            console.log(search)
          })
      }, 500)
    }
  }
}
</script>

<style scoped>
.topic-type {
  background-color: orange;
  border-radius: 15px;
}
</style>
