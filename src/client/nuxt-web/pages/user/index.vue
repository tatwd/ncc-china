<template>
  <div id="usercenter">
    <ncc-userinfo />
    <ncc-mycreate />
    <ncc-myjoin />
  </div>
</template>

<script>
import NccUserinfo from '~/components/user/NccUserinfo.vue'
import NccMycreate from '~/components/user/NccMycreate.vue'
import NccMyjoin from '~/components/user/NccMyjoin.vue'

export default {
  components: {
    NccUserinfo,
    NccMycreate,
    NccMyjoin
  }
}
</script>
