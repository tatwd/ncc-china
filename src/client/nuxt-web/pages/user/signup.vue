<template>
  <div id="signup">
    <el-form 
      class="register-box"
      ref="form"
    >
      <el-form-item >
        <el-input
          placeholder="请输入用户名"
          prefix-icon="el-icon-user"
        >
        </el-input>
      </el-form-item>
      <el-form-item>
        <el-input
          placeholder="请输入密码"
          prefix-icon="el-icon-search"
        >
        </el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="success" plain>登录</el-button>
      </el-form-item>
      <el-form-item>
        <el-button type="primary">通过 GitHub 账号登录</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
export default {
  name: 'signin',
  layout: 'account'
}
</script>

<style>
  #signup .register-box {
    position: fixed;
    display: block;
    padding: 20px;
    top: 50%;
    left: 50%;
    margin-top: -200px;
    margin-left: -150px;
    width: 300px;
    height: 400px;
    background-color: #fff;
    border: 2px solid #ccc;
    border-radius: 10px;
    text-align: center;
  }
</style>
