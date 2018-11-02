<template>
  <div id="ncc-myjoin">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>我参与的讨论</span>
      </div>
      <div
        v-for="(comment, index) in comments"
        :key="comment.id"
      >
        <div class="item-list mgtb10">
          <el-row
            type="flex"
            alidn="middle"
          >
            <el-col :sm="22">
              <nuxt-link to="/user">
                {{ comment.text }}
              </nuxt-link>
            </el-col>
            <el-col :sm="2">
              <el-button
                type="danger"
                icon="el-icon-delete"
                size="mini"
                title="删除"
                circle
                @click="deleteComment(index)"
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
    comments: {
      type: Array,
      default: () => {}
    }
  },
  methods: {
    deleteComment(index) {
      this.$confirm('此操作将永久删除该评论, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          this.$axios
            .delete(`v1/comments/${this.comments[index].id}`)
            .then(res => {
              this.$message({
                type: 'success',
                message: '删除成功!'
              })
              this.comments.splice(index, 1)
            })
            .catch(err => {
              console.log(err)
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
