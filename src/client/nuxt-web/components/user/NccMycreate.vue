<template>
  <div id="ncc-mycreate">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>我创建的帖子</span>
      </div>
      <div
        v-for="(post, index) in posts"
        :key="post.id"
      >
        <div class="item-list mgtb10">
          <el-row
            type="flex"
            alidn="middle"
          >
            <el-col :sm="22">
              <nuxt-link to="/user">
                {{ post.title }}
              </nuxt-link>
            </el-col>
            <el-col :sm="2">
              <el-button
                type="danger"
                icon="el-icon-delete"
                size="mini"
                title="删除"
                circle
                @click="deleteTopic(index)"
              />
            </el-col>
          </el-row>
        </div>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  props: {
    posts: {
      type: Array,
      default: () => {}
    }
  },
  methods: {
    deleteTopic(index) {
      this.$confirm('此操作将永久删除该话题, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          this.$axios
            .delete(`v1/user/posts/${this.posts[index].id}`)
            .then(res => {
              this.$message({
                type: 'success',
                message: '删除成功!'
              })
              this.posts.splice(index, 1)
            })
            .catch(err => {
              console.log('deleteTopic', err.statusText)
            })
        })
        .catch(() => {
          this.$message({
            type: 'info',
            message: '已取消删除'
          })
        })
    }
  }
}
</script>
