<template>
  <div id="users">
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span><nuxt-link to="/">主页</nuxt-link> / 用户信息</span>
      </div>
      <div class="ava-name mgb10">
        <img
          src="~/static/test.jpg"
          alt=""
          class="wh50 round vertical-middle"
        >
        <label class="fs16">ncc</label>
      </div>
      <div class="userid mgb10">
        <span>用户ID：</span>
        <label>121</label>
      </div>
      <div class="gender mgb10">
        <span>性别：</span>
        <label>未知</label>
      </div>
      <div class="createtime mgb10">
        <span>注册时间：</span>
        <label>2018-10-15</label>
      </div>
    </el-card>
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>他创建的话题</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
      >
        <div class="item-list mgtb10">
          <el-row
            type="flex"
            alidn="middle"
          >
            <el-col>
              <nuxt-link to="/user">
                {{ '话题 ' + o }}
              </nuxt-link>
            </el-col>
          </el-row>
        </div>
      </div>
    </el-card>
    <el-card shadow="hover">
      <div
        slot="header"
        class="clearfix"
      >
        <span>他参与的话题</span>
      </div>
      <div
        v-for="o in 4"
        :key="o"
      >
        <div class="item-list mgtb10">
          <el-row
            type="flex"
            alidn="middle"
          >
            <el-col>
              <nuxt-link to="/user">
                {{ '话题 ' + o }}
              </nuxt-link>
            </el-col>
          </el-row>
        </div>
      </div>
    </el-card>
  </div>
</template>
