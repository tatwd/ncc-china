<template>
  <div id="ncc-friendship">
    <el-card
      class="card-box"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>友情社区</span>
      </div>
      <div
        v-for="(friend, index) in friends"
        :key="index"
      >
        <a
          :href="friend.to"
          target="blank"
        >
          {{ friend.title }}
        </a>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  computed: {
    friends() {
      return [
        { title: 'Vue.js 中文社区', to: 'https://www.vue-js.com/' },
        { title: 'Node.js 中文社区', to: 'https://cnodejs.org/' },
        { title: '掘金-帮助开发者成长的社区', to: 'https://juejin.im/' }
      ]
    }
  }
}
</script>

<style>
</style>
