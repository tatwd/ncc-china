<template>
  <div id="dnc-slider">
    <dnc-unlogin />
    <dnc-ad />
    <dnc-topicnoreply />
    <dnc-integral />
    <dnc-communication />
    <dnc-friendship />
  </div>
</template>

<script>
import DncUnlogin from '~/components/shared/DncUnlogin.vue'
import DncAd from '~/components/shared/DncAd.vue'
import DncTopicnoreply from '~/components/shared/DncTopicnoreply.vue'
import DncIntegral from '~/components/shared/DncIntegral.vue'
import DncCommunication from '~/components/shared/DncCommunication.vue'
import DncFriendship from '~/components/shared/DncFriendship.vue'

export default {
  components: {
    DncUnlogin,
    DncAd,
    DncTopicnoreply,
    DncIntegral,
    DncCommunication,
    DncFriendship
  }
}
</script>

