<template>
  <div id="usercenter">
    <ncc-unread />
    <ncc-allmessage />
  </div>
</template>

<script>
import NccUnread from '~/components/user/NccUnread.vue'
import NccAllmessage from '~/components/user/NccAllmessage.vue'

export default {
  components: {
    NccUnread,
    NccAllmessage
  }
}
</script>
