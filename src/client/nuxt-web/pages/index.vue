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
            <a :href="topic.to">
              <div class="topic-list">
                <img
                  :src="topic.avatar"
                  alt=""
                >
                <span class="num">{{ topic.commentnum }}/{{ topic.browsenum }}</span>
                <span class="topic-type">{{ topic.type }}</span>
                <span>{{ topic.title }}</span>
                <span class="topic-time">{{ topic.time }}</span>
              </div>
            </a>
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
        { title: '精华', to: '/' },
        { title: '分享', to: '/' },
        { title: '问答', to: '/' },
        { title: '招聘', to: '/' }
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
          to: '/user/signin'
        },
        {
          avatar: require('../static/test.jpg'),
          commentnum: '39',
          browsenum: '46',
          type: '问答',
          title: '.NET Core 这个问题怎么解决?',
          time: '2018-10-05',
          to: '/user/signin'
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
.el-main {
  padding: 0;
}
.type-ul {
  padding: 0;
}
.type-li {
  display: inline;
  margin-right: 20px;
}
#app .el-main .el-card__body {
  padding: 0;
}
.topic-item {
  padding: 10px;
  height: 30px;
  border-bottom: 1px solid #aca0c7;
}
.topic-item img {
  width: 30px;
  vertical-align: middle;
}
.topic-item span {
  margin-left: 10px;
  vertical-align: middle;
}
.topic-item .topic-time {
  float: right;
}
</style>
