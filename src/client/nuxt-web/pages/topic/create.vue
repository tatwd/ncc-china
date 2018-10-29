<template>
  <div id="topic-create">
    <el-container>
      <el-header class="allw">
        <el-row
          type="flex"
          align="middle"
        >
          <el-col :sm="6">
            <router-link
              to="/"
              class="gohome"
            >
              <h1 class="mgtb10 fs16 dib">主页</h1>
            </router-link>
          </el-col>
          <el-col :sm="12">
            <h1 class="mgtb10 fs16">写文章</h1>
          </el-col>
          <el-col :sm="6">
            <ncc-flex justify="end">
              <el-button
                type="success"
                plain
                class="mglr10"
                @click="submitForm('topicform')"
              >
                发表文章
              </el-button>
              <a
                href="https://www.appinn.com/markdown/"
                target="_blank"
                rel="noopener noreferrer"
              >
                <el-button
                  type="primary"
                  plain
                >
                  Markdown 文档
                </el-button>
              </a>
            </ncc-flex>
          </el-col>
        </el-row>
      </el-header>
      <el-main>
        <el-row>
          <el-col
            :sm="12"
            :offset="6"
          >
            <el-card shadow="hover">
              <el-form
                ref="topicform"
                :model="topicform"
              >
                <el-input
                  v-model="model.title"
                  placeholder="请输入文章标题，字数10字以上"
                  class="input-with-select mgb10"
                >
                  <el-select
                    slot="prepend"
                    v-model="model.categoryId"
                    placeholder="请选择"
                  >
                    <el-option
                      v-for="item in options"
                      :key="item.id"
                      :label="item.title"
                      :value="item.id"
                    />
                  </el-select>
                </el-input>
                <no-ssr>
                  <mavon-editor
                    :subfield="false"
                    :toolbars="markdownOption"
                    :box-shadow="false"
                    v-model="mdValue"
                    @change="onchange"
                  />
                </no-ssr>
              </el-form>
            </el-card>
          </el-col>
        </el-row>
      </el-main>
    </el-container>
  </div>
</template>
<script>
import NccFlex from '~/components/shared/NccFlex.vue'
const markdownOption = {
  bold: false, // 粗体
  italic: false, // 斜体
  header: true, // 标题
  underline: false, // 下划线
  strikethrough: true, // 中划线
  mark: true, // 标记
  superscript: false, // 上角标
  subscript: false, // 下角标
  quote: true, // 引用
  ol: true, // 有序列表
  ul: true, // 无序列表
  link: true, // 链接
  imagelink: true, // 图片链接
  code: true, // code
  table: false, // 表格
  fullscreen: false, // 全屏编辑
  readmodel: false, // 沉浸式阅读
  htmlcode: true, // 展示html源码
  help: false, // 帮助
  undo: false, // 上一步
  redo: false, // 下一步
  trash: true, // 清空
  save: false, // 保存（触发events中的save事件）
  navigation: true, // 导航目录
  alignleft: true, // 左对齐
  aligncenter: true, // 居中
  alignright: true, // 右对齐
  subfield: true, // 单双栏模式
  preview: true // 预览
}

export default {
  middleware: 'unauth',
  layout: 'publish',
  components: {
    NccFlex
  },
  data() {
    return {
      markdownOption,
      mdValue: '',
      model: {
        author: {
          id: this.$store.state.auth.user.id,
          username: this.$store.state.auth.user.username,
          avatar_url: this.$store.state.auth.user.avatarUrl
        },
        categoryId: '',
        title: '',
        htmlText: ''
      }
    }
  },
  asyncData({ app }) {
    return app.$axios.$get('v1/categories').then(res => {
      return { options: res.data }
    })
  },
  methods: {
    onchange(value, html) {
      this.model.htmlText = html
    },
    submitForm(topicform) {
      setTimeout(() => {
        this.$axios.$post('v1/posts', this.model)
      })
    }
  }
}
</script>

<style scoped>
.el-header {
  position: fixed;
  background-color: #f9f9f9;
  border-bottom: 1px solid #ccc;
  z-index: 3000;
}
.el-card {
  margin-top: 60px;
}
.el-select {
  width: 130px;
}
.v-note-wrapper {
  min-height: 460px;
}
</style>
