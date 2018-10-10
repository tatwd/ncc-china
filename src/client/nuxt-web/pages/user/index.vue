<template>
  <div id="usercenter">
    <el-container class="content ncc-container">
      <el-main>
        <ncc-userinfo />
        <ncc-mycreate />
        <ncc-myjoin />
      </el-main>
      <el-aside width="340px">
        <ncc-logined />
        <ncc-createbtn />
        <ncc-ad />
        <ncc-topicnoreply />
        <ncc-integral />
        <ncc-communication />
        <ncc-friendship />
      </el-aside>
    </el-container>
  </div>
</template>

<script>
import NccUserinfo from '~/components/user/NccUserinfo.vue'
import NccMycreate from '~/components/user/NccMycreate.vue'
import NccMyjoin from '~/components/user/NccMyjoin.vue'
import NccLogined from '~/components/user/NccLogined.vue'
import NccCreatebtn from '~/components/topic/NccCreatebtn.vue'
import NccAd from '~/components/shared/NccAd.vue'
import NccTopicnoreply from '~/components/shared/NccTopicnoreply.vue'
import NccIntegral from '~/components/shared/NccIntegral.vue'
import NccCommunication from '~/components/shared/NccCommunication.vue'
import NccFriendship from '~/components/shared/NccFriendship.vue'

export default {
  components: {
    NccUserinfo,
    NccMycreate,
    NccMyjoin,
    NccLogined,
    NccCreatebtn,
    NccAd,
    NccTopicnoreply,
    NccIntegral,
    NccCommunication,
    NccFriendship
  }
}
</script>
