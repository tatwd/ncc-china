<template>
  <div id="apitest">
    <ul>
      <li
        v-for="(post, index) in posts"
        :key="index"
      >
        <h1>{{ post.userId }}</h1>
        <h2>{{ post.id }}</h2>
        <nuxt-link to="/">{{ post.title }}</nuxt-link>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from '~/plugins/axios'

export default {
  asyncData({ req, params }) {
    // We can return a Promise instead of calling the callback
    return axios.get('posts').then(res => {
      return { posts: res.data.slice(0, 50) }
    })
  }
}
</script>
