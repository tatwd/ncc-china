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
      <el-col :sm="12">
        <el-button
          v-for="(type, index) in types"
          :key="index"
          type="primary"
          size="small"
        >
          {{ type.title }}
        </el-button>
      </el-col>
      <el-col :sm="12">
        <ncc-flex justify="end">
          <span class="mglr10 pointer">按时间</span>
          <span class="mglr10 pointer">按热度</span>
        </ncc-flex>
      </el-col>
    </el-row>
    <div
      v-for="(topic, index) in topics"
      :key="index"
      index="index"
    >
      <el-card shadow="hover">
        <div class="topic-list">
          <img
            :src="topic.avatar"
            alt=""
            class="wh30 round vertical-middle"
          >
          <span class="topic-type mglr10 pdtb4 pdlr10 white pointer">
            {{ topic.type }}
          </span>
          <nuxt-link :to="topic.to">
            <span class="fs12">{{ topic.title }}</span>
          </nuxt-link>
          <div class="mgtb15">
            <span
              v-for="(tag, index) in tags"
              :key="index"
              class="tag pdtb4 pdlr10 fs8 pointer"
            >
              # {{ tag.name }}
            </span>
          </div>
          <el-row
            type="flex"
            align="middle"
          >
            <el-col :sm="12">
              <span>
                <i class="el-icon-view"> {{ topic.browsenum }}</i>
              </span>
              <span class="mglr10">
                <i class="el-icon-edit-outline"> {{ topic.commentnum }}</i>
              </span>
            </el-col>
            <el-col :sm="12">
              <ncc-flex justify="end">
                <span class="mglr10">{{ topic.time }}</span>
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
    },
    topics() {
      return [
        {
          avatar: require('../static/test.jpg'),
          commentnum: '39',
          browsenum: '46',
          type: '问答',
          title: '.NET Core 这个问题怎么解决?',
          time: '2018-10-05',
          to: '/topic/1'
        },
        {
          avatar: require('../static/test.jpg'),
          commentnum: '39',
          browsenum: '46',
          type: '问答',
          title: '.NET Core 这个问题怎么解决?',
          time: '2018-10-05',
          to: '/topic/2'
        }
      ]
    },
    tags() {
      return [{ name: '问答' }, { name: '招聘' }]
    }
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
