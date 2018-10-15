<template>
  <section id="app">
    <el-card
      class="card-box card-title"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span
          v-for="(type, index) in types"
          :key="index"
          class="px-1"
        >
          {{ type.title }}
        </span>
      </div>
    </el-card>
    <div
      v-for="(topic, index) in topics"
      :key="index"
      index="index"
      class="topic-item"
    >
      <el-card
        class="box-card"
        shadow="hover"
      >
        <div class="topic-list">
          <nuxt-link :to="topic.to">
            <div>
              <img
                :src="topic.avatar"
                alt=""
              >
              <span class="topic-type">{{ topic.type }}</span>
              <span class="topic-title">{{ topic.title }}</span>
            </div>
            <!-- <div class="topic-abstract">
              {{ topic.abstract }}
            </div> -->
          </nuxt-link>
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
export default {
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
:root {
  --init-size: 5px;
}

.px-1 {
  padding-left: calc(1 * var(--init-size));
  padding-right: calc(1 * var(--init-size));
}

.px-2 {
  padding-left: calc(2 * var(--init-size));
  padding-right: calc(2 * var(--init-size));
}
.card-title .el-card__body {
  padding: 0;
}
#app .el-main .el-card__body {
  padding: 0;
}
.topic-item .el-card__body {
  margin-bottom: 0;
  padding: 15px;
}
.topic-item img {
  width: 30px;
  height: 30px;
  border-radius: 50%;
  vertical-align: middle;
}
.topic-item .mt-1 {
  margin-top: 15px;
}
.topic-item span {
  margin-top: 10px;
  vertical-align: middle;
}
.topic-list .commentnum {
  margin-left: 10px;
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
