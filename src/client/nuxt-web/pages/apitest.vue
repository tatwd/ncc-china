<template>
  <div id="apitest">
    <!-- <ul>
      <li
        v-for="(post, index) in posts"
        :key="index"
      >
        <nuxt-link to="/">{{ post.bookname }}</nuxt-link>
      </li>
    </ul> -->
    <pre>{{ data }}</pre>
  </div>
</template>

<script>
export default {
  async asyncData({ app }) {
    let _data = 'hello world'
    _data = await app.$axios.$get('/')
    // .then(res => {
    //   console.log(res)
    //   _data = JSON.stringify(res)
    // })
    // .catch(err => {
    //   console.log(res.config)
    // })

    return {
      data: _data
    }
  },
  created() {
    this.$axios
      .$get('/')
      .then(res => {
        console.log(res)
      })
      .catch(err => {
        console.log(res.config)
      })
  }
}
</script>
