<template>
  <section id="app">
    <el-card shadow="never">
      <el-button
        v-for="(type, index) in types"
        :key="index"
        size="small"
      >
        {{ type.title }}
      </el-button>
      <ncc-flex justify="end">
        <span>按时间</span>
        <span>按热度</span>
      </ncc-flex>
    </el-card>
    <div
      v-for="(topic, index) in topics"
      :key="index"
      index="index"
    >
      <el-card shadow="hover">
        <div class="topic-list">
          <nuxt-link :to="topic.to">
            <div class="topic-top">
              <img
                :src="topic.avatar"
                alt=""
                class="imgw30 round vertical-moddle"
              >
              <span class="topic-type">{{ topic.type }}</span>
              <span class="topic-title">{{ topic.title }}</span>
            </div>
          </nuxt-link>
          <div class="mrtb10">
            <span
              v-for="(tag, index) in tags"
              :key="index"
              class="tag"
            >
              {{ tag.name }}
            </span>
          </div>
          <div class="mt-1">
            <span class="browsenum">
              <i class="el-icon-view"> {{ topic.browsenum }}</i>
            </span>
            <span class="commentnum">
              <i class="el-icon-edit-outline"> {{ topic.commentnum }}</i>
            </span>
            <span class="topic-time">{{ topic.time }}</span>
          </div>
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

<style>
</style>
