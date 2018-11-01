<template>
  <div id="setting">
    <ncc-updateinfo />
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
  }
}
</script>
