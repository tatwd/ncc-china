<template>
  <div id="topic-create">
    <el-container class="content ncc-container">
      <el-main>
        <el-card
          class="box-card"
          shadow="hover"
        >
          <div
            slot="header"
            class="clearfix"
          >
            <span><router-link to="/">主页</router-link> / 发布话题</span>
          </div>
          <div>
            <label>请选择话题类型：</label>
            <el-select
              v-model="topicType"
              placeholder="请选择"
            >
              <el-option
                v-for="item in options"
                :key="item.topicType"
                :label="item.label"
                :value="item.topicType"
              />
            </el-select>
            <el-input
              v-model="topicTitle"
              placeholder="请输入话题标题，字数10字以上"
              class="topic-title"
            />
          </div>
        </el-card>
      </el-main>
      <el-aside>
        <ncc-markdown />
        <ncc-guide />
      </el-aside>
    </el-container>
  </div>
</template>
<script>
import NccMarkdown from '~/components/topic/NccMarkdown.vue'
import NccGuide from '~/components/topic/NccGuide.vue'

export default {
  components: {
    NccMarkdown,
    NccGuide
  },
  data() {
    return {
      options: [
        {
          topicType: '选项1',
          label: '分享'
        },
        {
          topicType: '选项2',
          label: '问答'
        },
        {
          topicType: '选项3',
          label: '招聘'
        }
      ],
      topicType: '',
      topicTitle: ''
    }
  }
}
</script>

<style scoped>
#topic-create .topic-title {
  margin-top: 10px;
}
</style>
