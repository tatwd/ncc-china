<template>
  <div id="ncc-slider">
    <ncc-createbtn />
    <ncc-hottopic />
    <ncc-ad />
    <ncc-topicnoreply />
    <ncc-integral />
    <ncc-communication />
    <ncc-friendship />
  </div>
</template>

<script>
import NccCreatebtn from '~/components/topic/NccCreatebtn.vue'
import NccHottopic from '~/components/topic/NccHottopic.vue'
import NccAd from '~/components/shared/NccAd.vue'
import NccTopicnoreply from '~/components/shared/NccTopicnoreply.vue'
import NccIntegral from '~/components/shared/NccIntegral.vue'
import NccCommunication from '~/components/shared/NccCommunication.vue'
import NccFriendship from '~/components/shared/NccFriendship.vue'

export default {
  components: {
    NccCreatebtn,
    NccHottopic,
    NccAd,
    NccTopicnoreply,
    NccIntegral,
    NccCommunication,
    NccFriendship
  }
}
</script>
