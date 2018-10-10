<template>
  <div id="hotuser">
    <el-container class="content ncc-container">
      <el-main>
        <el-card
          class="box-card"
          shadow="hover"
        >
          <div
            slot="header"
            class="clearfix"
          >
            <span><router-link to="/">主页</router-link> / 热门用户</span>
          </div>
          <div
            v-for="(hotuser, index) in hotusers"
            :key="index"
            index="index"
            class="user-list"
          >
            <img
              :src="hotuser.ava"
              alt=""
            >
            <span>{{ hotuser.name }}</span>
            <span>{{ hotuser.jifen }}</span>
          </div>
        </el-card>
      </el-main>
      <el-aside width="340px">
        <ncc-hottopic />
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
import NccHottopic from '~/components/topic/NccHottopic.vue'
import NccAd from '~/components/shared/NccAd.vue'
import NccTopicnoreply from '~/components/shared/NccTopicnoreply.vue'
import NccIntegral from '~/components/shared/NccIntegral.vue'
import NccCommunication from '~/components/shared/NccCommunication.vue'
import NccFriendship from '~/components/shared/NccFriendship.vue'

export default {
  components: {
    NccHottopic,
    NccAd,
    NccTopicnoreply,
    NccIntegral,
    NccCommunication,
    NccFriendship
  },
  computed: {
    hotusers() {
      return [
        {
          ava: require('../../static/test.jpg'),
          name: 'test',
          jifen: 100
        }
      ]
    }
  }
}
</script>

<style scoped>
#hotuser img {
  width: 30px;
  height: 30px;
  border-radius: 50%;
  vertical-align: middle;
}
#hotuser .user-list span {
  margin-left: 20px;
  vertical-align: middle;
}
</style>
