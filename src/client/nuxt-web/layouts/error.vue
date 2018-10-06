<template>
  <div id="layout--error">
    <div class="error-message">
      <h2>{{ errorMsg }}</h2>
      <p>
        <router-link to="/">{{ linkMsg }}</router-link>
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Error',
  data: () => ({
    errorMsg: '404',
    linkMsg: '返回首页'
  })
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
a {
  text-decoration: none;
  color: #222;
  border-bottom: 2px solid transparent;
}
a:hover {
  color: #c66;
  border-bottom: 2px solid #c66;
}
</style>
