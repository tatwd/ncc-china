<template>
  <div id="apitest">
    <ul>
      <li
        v-for="(post, index) in posts"
        :key="index"
      >
        <nuxt-link to="/">{{ post.name }}</nuxt-link>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from '~/plugins/axios'

export default {
  asyncData({ req, params }) {
    // We can return a Promise instead of calling the callback
    return axios.get('api/xiandu/categories').then(res => {
      return { posts: res.data.results }
    })
  }
  // async asyncData() {
  //   let { data } = await axios.get('api/xiandu/categories')
  //   console.log(data)
  //   return { posts: data.results }
  // }
}
</script>
