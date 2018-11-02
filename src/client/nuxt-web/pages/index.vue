<template>
  <div
    id="app"
    class="mgt10"
  >
    <el-input
      v-model="searchform.search"
      placeholder="请选择搜索内容"
      suffix-icon="el-icon-search"
      class="mgb10"
      @keyup.enter.native="search"
    />
    <el-row
      type="flex"
      align="middle"
    >
      <el-col>
        <el-button
          type="primary"
          size="small"
          @click="changetype('全部')"
        >
          全部
        </el-button>
        <el-button
          v-for="(type, index) in types"
          :key="index"
          type="primary"
          size="small"
          @click="changetype(type.title)"
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
          <el-tag
            type="success"
            size="small"
          >
            {{ post.category.title }}
          </el-tag>
          <nuxt-link :to="`/post/`+post.id">
            <span class="">{{ post.title }}</span>
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
              <nuxt-link :to="`/user/`+post.author.id">
                <img
                  :src="post.author.avatarUrl"
                  alt=""
                  class="wh30 round vertical-middle"
                >
              </nuxt-link>
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
  </div>
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
  async asyncData({ app }) {
    let posts = await app.$axios.$get('v1/posts', {
      params: {
        page: 1,
        limit: 10,
        category: '全部',
        desc: true
      }
    })
    let categories = await app.$axios.$get('v1/categories')
    return {
      posts: posts.data,
      types: categories.data
    }
  },
  methods: {
    search() {
      setTimeout(() => {
        this.$axios
          .$get('v1/posts', {
            params: {
              query: this.searchform.search,
              page: 1,
              limit: 10,
              category: '全部',
              desc: true
            }
          })
          .then(res => {
            // console.log(res)
            this.posts = res.data
          })
          .catch(err => {
            console.log('search', err.statusText)
          })
      }, 100)
    },
    changetype(title) {
      this.$axios
        .$get('v1/posts', {
          params: {
            query: this.searchform.search,
            page: 1,
            limit: 10,
            category: title,
            desc: true
          }
        })
        .then(res => {
          this.posts = res.data
        })
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
