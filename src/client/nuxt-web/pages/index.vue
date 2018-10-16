<template>
  <section id="app">
    <ncc-search />
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
          <span class="mrlr10 pointer">按时间</span>
          <span class="mrlr10 pointer">按热度</span>
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
          <div class="topic-top ">
            <img
              :src="topic.avatar"
              alt=""
              class="wh30 round vertical-middle"
            >
            <span class="topic-type mrlr10 pdtb4 pdlr10 text-white pointer">
              {{ topic.type }}
            </span>
            <nuxt-link :to="topic.to">
              <span class="fs12">{{ topic.title }}</span>
            </nuxt-link>
          </div>
          <div class="mrtb15">
            <span
              v-for="(tag, index) in tags"
              :key="index"
              class="tag mrlr10 pdtb4 pdlr10 pointer"
            >
              {{ tag.name }}
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
              <span class="mrlr10">
                <i class="el-icon-edit-outline"> {{ topic.commentnum }}</i>
              </span>
            </el-col>
            <el-col :sm="12">
              <ncc-flex justify="end">
                <span class="mrlr10">{{ topic.time }}</span>
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
import NccSearch from '~/components/shared/NccSearch.vue'

export default {
  components: {
    NccFlex,
    NccSearch
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
          to: '/topic/detail',
          abstract:
            '这是文章摘要！墨守陈规文案狗： 旧金山街头，一名华裔男子在街头驾驶一辆Audi R8跑车，一名白人男子疑似不满跑车引擎声音太大，直接朝他的车用力踹了一脚，气得华裔男子立刻下车与对方理论，双方开始斗殴。'
        },
        {
          avatar: require('../static/test.jpg'),
          commentnum: '39',
          browsenum: '46',
          type: '问答',
          title: '.NET Core 这个问题怎么解决?',
          time: '2018-10-05',
          to: '/topic/detail',
          abstract:
            '这是文章摘要！墨守陈规文案狗： 旧金山街头，一名华裔男子在街头驾驶一辆Audi R8跑车，一名白人男子疑似不满跑车引擎声音太大，直接朝他的车用力踹了一脚，气得华裔男子立刻下车与对方理论，双方开始斗殴。'
        }
      ]
    },
    tags() {
      return [{ name: '问答' }, { name: '招聘' }]
    }
  }
}
</script>

<style scoped>
.topic-type {
  background-color: orange;
  border-radius: 15px;
}
.tag {
  background-color: #ccc;
  border-radius: 15px;
}
</style>
