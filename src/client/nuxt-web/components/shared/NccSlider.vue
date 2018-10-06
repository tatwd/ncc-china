<template>
  <div id="ncc-slider">
    <ncc-unlogin />
    <ncc-createbtn />
    <ncc-ad />
    <ncc-topicnoreply />
    <ncc-integral />
    <ncc-communication />
    <ncc-friendship />
  </div>
</template>

<script>
import NccUnlogin from '~/components/shared/NccUnlogin.vue'
import NccCreatebtn from '~/components/topic/NccCreatebtn.vue'
import NccAd from '~/components/shared/NccAd.vue'
import NccTopicnoreply from '~/components/shared/NccTopicnoreply.vue'
import NccIntegral from '~/components/shared/NccIntegral.vue'
import NccCommunication from '~/components/shared/NccCommunication.vue'
import NccFriendship from '~/components/shared/NccFriendship.vue'

export default {
  components: {
    NccUnlogin,
    NccCreatebtn,
    NccAd,
    NccTopicnoreply,
    NccIntegral,
    NccCommunication,
    NccFriendship
  }
}
</script>
