<template>
  <div id="ncc-interaction">
    <el-card
      class="cox-card"
      shadow="hover"
    >
      <div>
        <div
          v-for="(comment, index) in comments"
          :key="index"
          index="index"
        >
          <img
            :src="comment.ava"
            alt=""
          >
          <span>{{ comment.name }}</span>
          <span>{{ comment.time }}</span>
          <p>{{ comment.content }}</p>
          <span>回复</span>
          <el-form
            :model="replyform"
            rel="commentform"
          >
            <el-input
              :autosize="{ minRows: 2, maxRows: 4}"
              v-model="replytextarea"
              type="textarea"
              placeholder="请输入回复内容"
            />
            <el-button
              type="success"
              plain
              @click="subForm('replyform')"
            >
              提交
            </el-button>
          </el-form>
          <div
            v-for="(reply, index) in replys"
            :key="index"
            index="index"
          >
            <img
              :src="reply.ava"
              alt=""
            >
            <span>{{ reply.name }}</span>
            <span>{{ reply.time }}</span>
            <p>{{ reply.content }}</p>
            <span>回复</span>
            <el-form
              :model="replyform"
              rel="reply1form"
            >
              <el-input
                :autosize="{ minRows: 2, maxRows: 4}"
                v-model="replytextarea"
                type="textarea"
                placeholder="请输入回复内容"
              />
              <el-button
                type="success"
                plain
                @click="subForm('reply1form')"
              >
                提交
              </el-button>
            </el-form>
          </div>
        </div>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      replytextarea: ''
    }
  },
  computed: {
    comments() {
      return [
        {
          ava: require('../../static/test.jpg'),
          name: 'test',
          time: '2018-10-10',
          content: '这是评论'
        }
      ]
    },
    replys() {
      return [
        {
          ava: require('../../static/test.jpg'),
          name: 'test1',
          time: '2018-10-10',
          content: '这是回复'
        }
      ]
    }
  }
}
</script>

<style scoped>
#ncc-interaction img {
  width: 30px;
  height: 30px;
  border-radius: 50%;
  vertical-align: middle;
}
#ncc-interaction span {
  vertical-align: middle;
}
</style>
