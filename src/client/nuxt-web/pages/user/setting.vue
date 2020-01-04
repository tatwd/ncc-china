<template>
  <div id="setting">
    <ncc-updateinfo
      :currentuser="currentuser"
    />
    <ncc-updatepwd />
  </div>
</template>

<script>
import NccUpdateinfo from '~/components/user/NccUpdateinfo.vue'
import NccUpdatepwd from '~/components/user/NccUpdatepwd.vue'

export default {
  middleware: 'unauth',
  components: {
    NccUpdateinfo,
    NccUpdatepwd
  },
  async asyncData({ $axios, store }) {
    $axios.setToken(store.state.auth.token, 'Bearer')
    let currentuser = await $axios.$get('v1/user')
    return {
      currentuser: currentuser.data
    }
  }
}
</script>
