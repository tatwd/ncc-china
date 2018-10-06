<template>
  <div id="goTop">
    <div
      v-show="goTopShow"
      class="goTop"
      @click="goTop"
    >
      <i class="el-icon-arrow-up" />
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      scrollTop: '',
      goTopShow: false
    }
  },
  mounted() {
    window.addEventListener('scroll', this.handleScroll)
  },
  destroyed() {
    window.removeEventListener('scroll', this.handleScroll)
  },
  methods: {
    handleScroll() {
      this.scrollTop =
        window.pageYOffset ||
        document.documentElement.scrollTop ||
        document.body.scrollTop
      this.scrollTop > 500 ? (this.goTopShow = true) : (this.goTopShow = false)
    },
    goTop() {
      let timer = null,
        _that = this
      cancelAnimationFrame(timer)
      timer = requestAnimationFrame(function fn() {
        if (_that.scrollTop > 0) {
          _that.scrollTop -= 50
          document.body.scrollTop = document.documentElement.scrollTop =
            _that.scrollTop
          timer = requestAnimationFrame(fn)
        } else {
          cancelAnimationFrame(timer)
          _that.goTopShow = false
        }
      })
    }
  }
}
</script>

<style scoped>
.goTop {
  position: fixed;
  right: 50px;
  bottom: 100px;
  width: 50px;
  height: 50px;
  background: rgba(0, 0, 0, 0.65);
  border-radius: 50%;
  cursor: pointer;
}
.goTop:hover {
  background: rgba(0, 0, 0, 0.85);
}
i {
  position: absolute;
  top: 17px;
  left: 17px;
}
</style>
