<template>
  <div id="search">
    <el-form
      ref="searchform"
      :model="searchform"
      class="mgt10"
    >
      <el-form-item prop="search">
        <el-input
          v-model="searchform.search"
          placeholder="请输入内容"
        >
          <el-button
            slot="append"
            icon="el-icon-search"
            @click="search"
          />
        </el-input>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      searchform: {
        search: ''
      }
    }
  },
  methods: {
    search() {
      setTimeout(() => {
        this.$axios
          .$post('', {
            search: this.searchform.search
          })
          .then(res => {
            console.log(res)
          })
      })
    }
  }
}
</script>
