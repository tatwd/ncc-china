<template>
  <div id="ncc-mycreate">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>我创建的话题</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
      >
        <div class="item-list mrtb10">
          <el-row
            type="flex"
            alidn="middle"
          >
            <el-col :sm="22">
              <nuxt-link to="/user">
                {{ '话题 ' + o }}
              </nuxt-link>
            </el-col>
            <el-col :sm="2">
              <el-button
                type="danger"
                icon="el-icon-delete"
                size="mini"
                title="删除"
                circle
                @click="deleteTopic"
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
  // mounted: {
  //   async fetchUserinfo() {
  //     const mycreate = await this.$axios.$get('')
  //     this.mycreate = mycreate
  //   }
  // },
  methods: {
    deleteTopic() {
      this.$confirm('此操作将永久删除该话题, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          this.$message({
            type: 'success',
            message: '删除成功!'
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
