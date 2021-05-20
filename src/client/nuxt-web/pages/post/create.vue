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
              <el-form>
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
            <el-tag
              v-for="tag in model.tags"
              :key="tag"
              :disable-transitions="false"
              closable
              @close="handleClose(tag)"
            >
              {{ tag }}
            </el-tag>
            <el-input
              v-if="inputVisible"
              ref="saveTagInput"
              v-model="inputValue"
              size="small"
              class="input-new-tag"
              @keyup.enter.native="handleInputConfirm"
              @blur="handleInputConfirm"
            />
            <el-button
              v-else
              size="small"
              class="button-new-tag"
              @click="showInput"
            >
              + 添加新标签
            </el-button>
          </el-col>
        </el-row>
      </el-main>
    </el-container>
  </div>
</template>
<script>
import NccFlex from '~/components/shared/NccFlex.vue'
import markdownOption from '~/config/MavonEditor.js'

export default {
  middleware: 'unauth',
  layout: 'publish',
  components: {
    NccFlex
  },
  data() {
    let { id, username, avatarUrl, email } = this.$store.state.auth.user
    return {
      markdownOption,
      mdValue: '',
      model: {
        author: {
          id,
          username,
          avatarUrl,
          email
        },
        categoryId: '',
        title: '',
        htmlText: '',
        tags: []
      },
      dynamicTags: [],
      inputVisible: false,
      inputValue: ''
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
        this.$axios
          .$post('v1/posts', this.model)
          .then(res => {
            if (res.code == 0) {
              this.$router.push('/')
            }
          })
          .catch(err => {
            console.log(err)
          })
      })
    },
    handleClose(tag) {
      this.model.tags.splice(this.model.tags.indexOf(tag), 1)
    },

    showInput() {
      this.inputVisible = true
      this.$nextTick(_ => {
        this.$refs.saveTagInput.$refs.input.focus()
      })
    },
    handleInputConfirm() {
      let inputValue = this.inputValue
      if (inputValue) {
        this.model.tags.push(inputValue)
      }
      this.inputVisible = false
      this.inputValue = ''
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
.el-tag + .el-tag {
  margin-left: 10px;
}
.button-new-tag {
  margin-left: 10px;
  height: 32px;
  line-height: 30px;
  padding-top: 0;
  padding-bottom: 0;
}
.input-new-tag {
  width: 90px;
  margin-left: 10px;
  vertical-align: bottom;
}
</style>
