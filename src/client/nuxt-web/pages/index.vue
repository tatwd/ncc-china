<template>
  <section id="app">

      <el-container class="content">
        <el-main>
          <el-card
            class="card-box"
            shadow="hover"
          >
            <div slot="header" class="clearfix">
              <ul class="type-ul">
                <li
                  v-for="(type, index) in types"
                  :key="index"
                  index="index"
                  class="type-li"
                >
                  {{type.title}}
                </li>
              </ul>
            </div>
            <div v-for="o in 4" :key="o" class="topic-item">
              {{'话题 ' + o }}
            </div>
          </el-card>
        </el-main>
        <el-aside width="340px">
          <dnc-slider />
        </el-aside>
      </el-container>
  </section>
</template>

<script>
import DncSlider from '~/components/shared/DncSlider.vue'

export default {
  components: {
    DncSlider
  },
  computed: {
    types() {
      return [
        {title: '全部', to: '/'},
        {title: '精华', to: '/'},
        {title: '分享', to: '/'},
        {title: '问答', to: '/'},
        {title: '招聘', to: '/'}
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
    padding: 0 20px;
  }
</style>

