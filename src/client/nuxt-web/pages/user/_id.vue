<template>
  <div id="users">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / 用户信息</span>
      </div>
      <div class="ava-name mgb10">
        <img
          :src="user.avatarUrl"
          alt=""
          class="wh50 round vertical-middle"
        >
        <label class="fs16">{{ user.username }}</label>
      </div>
      <div class="userid mgb10">
        <span>用户ID：</span>
        <label>{{ user.id }}</label>
      </div>
      <div class="gender mgb10">
        <span>Email：</span>
        <label>{{ user.email }}</label>
      </div>
      <div class="gender mgb10">
        <span>性别：</span>
        <label>{{ user.gender }}</label>
      </div>
      <div class="gender mgb10">
        <span>个人简介：</span>
        <label>{{ user.bio }}</label>
      </div>
      <div class="createtime mgb10">
        <span>注册时间：</span>
        <label>{{ user.utcCreated }}</label>
      </div>
    </el-card>
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>他创建的帖子</span>
      </div>
      <div v-if="hisposts.lenght === 0">
        <div>该用户暂无发表帖子</div>
      </div>
      <div
        v-for="post in hisposts"
        :key="post.id"
      >
        <div class="item-list mgtb10">
          <el-row
            type="flex"
            alidn="middle"
          >
            <el-col>
              <nuxt-link :to="`/post/` + post.id">
                {{ post.title }}
              </nuxt-link>
            </el-col>
          </el-row>
        </div>
      </div>
    </el-card>
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>他参与的讨论</span>
      </div>
      <div v-if="hiscomments.lenght === 0">
        <div>该用户暂无发表评论</div>
      </div>
      <div
        v-for="comment in hiscomments"
        :key="comment.id"
      >
        <div class="item-list mgtb10">
          <el-row
            type="flex"
            alidn="middle"
          >
            <el-col>
              <nuxt-link :to="`/post/` + comment.postId">
                {{ comment.text }}
              </nuxt-link>
            </el-col>
          </el-row>
        </div>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  async asyncData({ app, params }) {
    let user = await app.$axios.$get(`v1/users/${params.id}`)
    let hisposts = await app.$axios.$get(`v1/users/${params.id}/posts`)
    let hiscomments = await app.$axios.$get(`v1/users/${params.id}/comments`)
    return {
      user: user.data,
      hisposts: hisposts.data,
      hiscomments: hiscomments.data
    }
  }
}
</script>
