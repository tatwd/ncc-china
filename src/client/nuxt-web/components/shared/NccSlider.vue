<template>
  <div id="ncc-slider">
    <ncc-createbtn />
    <ncc-hotpost />
    <ncc-ad />
    <!-- <ncc-postnoreply />
    <ncc-integral /> -->
    <ncc-communication />
    <ncc-friendship />
  </div>
</template>

<script>
import NccCreatebtn from '~/components/post/NccCreatebtn.vue'
import NccHotpost from '~/components/post/NccHotpost.vue'
import NccAd from '~/components/shared/NccAd.vue'
// import NccPostnoreply from '~/components/shared/Nccpostnoreply.vue'
// import NccIntegral from '~/components/shared/NccIntegral.vue'
import NccCommunication from '~/components/shared/NccCommunication.vue'
import NccFriendship from '~/components/shared/NccFriendship.vue'

export default {
  components: {
    NccCreatebtn,
    NccHotpost,
    NccAd,
    // NccPostnoreply,
    // NccIntegral,
    NccCommunication,
    NccFriendship
  }
}
</script>
