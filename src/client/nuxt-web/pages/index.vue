<template>
  <section id="app">
    <el-container class="content ncc-container">
      <el-main>
        <el-card
          class="card-box"
          shadow="hover"
        >
          <div
            slot="header"
            class="clearfix"
          >
            <ul class="type-ul">
              <li
                v-for="(type, index) in types"
                :key="index"
                index="index"
                class="type-li"
              >
                {{ type.title }}
              </li>
            </ul>
          </div>
          <div
            v-for="(topic, index) in topics"
            :key="index"
            index="index"
            class="topic-item"
          >
            <div class="topic-list">
              <nuxt-link :to="topic.to">
                <img
                  :src="topic.avatar"
                  alt=""
                >
                <span class="topic-type">{{ topic.type }}</span>
                <span class="topic-title">{{ topic.title }}</span>
                <div class="topic-abstract">
                  {{ topic.abstract }}
                </div>
              </nuxt-link>
              <span class="browsenum">
                <i class="el-icon-view"> {{ topic.browsenum }} 次阅读</i>
              </span>
              <span class="commentnum">
                <i class="el-icon-edit-outline"> {{ topic.commentnum }} 条评论</i>
              </span>
              <span class="topic-time">{{ topic.time }}</span>
            </div>
          </div>
        </el-card>
      </el-main>
      <el-aside width="340px">
        <ncc-slider />
      </el-aside>
    </el-container>
  </section>
</template>

<script>
import NccSlider from '~/components/shared/NccSlider.vue'

export default {
  components: {
    NccSlider
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
    }
  }
}
</script>

<style>
.el-header,
.el-footer {
  padding: 0;
}
.type-ul {
  padding: 0;
}
.type-li {
  display: inline;
  margin: 0 10px;
}
#app .el-main .el-card__body {
  padding: 0;
}
.topic-item {
  padding: 20px;
  border-bottom: 1px solid #ccc;
}
.topic-item img {
  width: 30px;
  height: 30px;
  border-radius: 50%;
  vertical-align: middle;
}
.topic-item span {
  margin-left: 10px;
  vertical-align: middle;
}
.topic-list .commentnum {
  margin-left: 40px;
}
.topic-list .topic-type {
  color: orange;
}
.topic-list .topic-title {
  color: #222;
  font-size: 20px;
  font-weight: 700;
}
.topic-list .topic-abstract {
  margin: 20px 0;
}
.topic-item .topic-time {
  float: right;
  margin-top: 4px;
}
</style>
