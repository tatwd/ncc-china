<template>
  <div id="layout--error">
    <div class="error-message">
      <h1 v-if="error.statusCode === 404">Page not found</h1>
      <h1 v-else>An error occurred</h1>
      <nuxt-link to="/">回到首页</nuxt-link>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Error',
  props: {
    error: {
      type: Object,
      default: null
    }
  }
}
</script>

<style scoped>
#layout--error {
  display: flex;
  height: 100vh;
}
.error-message {
  margin: auto;
  text-align: center;
}
</style>
