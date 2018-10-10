<template>
  <div id="setting">
    <el-container class="content ncc-container">
      <el-main>
        <ncc-updateinfo />
        <ncc-updatepwd />
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
import NccUpdateinfo from '~/components/user/NccUpdateinfo.vue'
import NccUpdatepwd from '~/components/user/NccUpdatepwd.vue'
import NccLogined from '~/components/user/NccLogined.vue'
import NccCreatebtn from '~/components/topic/NccCreatebtn.vue'
import NccAd from '~/components/shared/NccAd.vue'
import NccTopicnoreply from '~/components/shared/NccTopicnoreply.vue'
import NccIntegral from '~/components/shared/NccIntegral.vue'
import NccCommunication from '~/components/shared/NccCommunication.vue'
import NccFriendship from '~/components/shared/NccFriendship.vue'

export default {
  components: {
    NccUpdateinfo,
    NccUpdatepwd,
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
