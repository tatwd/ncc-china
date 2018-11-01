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
  async asyncData({ app }) {
    let currentuser = await app.$axios.$get('v1/user')
    console.log(currentuser)
    return {
      currentuser: currentuser.data
    }
  }
}
</script>
