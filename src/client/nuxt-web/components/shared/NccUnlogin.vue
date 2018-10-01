<template>
  <div id="dnc-unlogin">
    <el-card 
      class="box-card" 
      shadow="hover"
    >
      <div 
        slot="header" 
        class="clearfix"
      >
        <span>.NET Core 专业中文社区</span>
      </div>
      <div>
        <p>您可以 <span link-to:>登录</span> 或 <span link-to:>注册</span>，也可以</p>
        <el-button type="primary">通过 GitHub 登录</el-button>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {

}
</script>

<style>
  #dnc-unlogin p {
    margin-bottom: 20px;
  }
  #dnc-unlogin span {
    color: #682079;
  }
</style>

