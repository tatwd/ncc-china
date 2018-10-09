<template>
  <div id="topic-create">
    <el-container>
      <el-header>
        <router-link
          to="/"
          class="gohome"
        >
          主页
        </router-link>
        写文章
        <a
          href="https://www.appinn.com/markdown/"
          target="_blank"
          rel="noopener noreferrer"
          class="markdown"
        >
          <el-button
            type="primary"
            plain
          >
            Markdown 文档
          </el-button>
        </a>
        <el-button
          type="success"
          plain
          class="publish-btn"
        >
          发表文章
        </el-button>
      </el-header>
      <el-container class="content ncc-container">
        <el-main>
          <el-card
            class="box-card"
            shadow="hover"
          >
            <div>
              <el-form>
                <label>请选择一种文章标签方便检索：</label>
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
                <no-ssr>
                  <mavon-editor
                    :toolbars="markdownOption"
                    v-model="markdownhandbook"
                  />
                </no-ssr>
              </el-form>
            </div>
          </el-card>
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>
<script>
export default {
  layout: 'publish',
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
      topicTitle: '',
      markdownhandbook: '',
      markdownOption: {
        bold: true, // 粗体
        italic: true, // 斜体
        header: true, // 标题
        underline: true, // 下划线
        strikethrough: true, // 中划线
        mark: true, // 标记
        superscript: true, // 上角标
        subscript: true, // 下角标
        quote: true, // 引用
        ol: true, // 有序列表
        ul: true, // 无序列表
        link: true, // 链接
        imagelink: true, // 图片链接
        code: true, // code
        table: true, // 表格
        fullscreen: false, // 全屏编辑
        readmodel: false, // 沉浸式阅读
        htmlcode: true, // 展示html源码
        help: true, // 帮助
        undo: true, // 上一步
        redo: true, // 下一步
        trash: true, // 清空
        save: true, // 保存（触发events中的save事件）
        navigation: true, // 导航目录
        alignleft: true, // 左对齐
        aligncenter: true, // 居中
        alignright: true, // 右对齐
        subfield: true, // 单双栏模式
        preview: true // 预览
      }
    }
  }
}
</script>

<style scoped>
#topic-create .el-header {
  position: fixed;
  padding: 0 15px;
  width: 100%;
  background-color: #f9f9f9;
  border-bottom: 1px solid #ccc;
  font-size: 20px;
  font-weight: 700;
  line-height: 60px;
  text-align: center;
  z-index: 3000;
}
#topic-create .publish-btn,
#topic-create .markdown .el-button {
  float: right;
  margin: 10px;
}
#topic-create .gohome {
  float: left;
}
#topic-create .ncc-container {
  width: 800px;
}
#topic-create .el-card {
  margin-top: 70px;
}
#topic-create .topic-title {
  margin: 10px 0;
}
</style>
