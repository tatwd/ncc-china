<template>
  <div class="layout-account">
    <nuxt />
    <canvas id="particle-animation"></canvas>
  </div>
</template>

<script>
import particleAnimation from '~/assets/js/particle-animation.js'

export default {
  name: 'account',
  mounted () {
    particleAnimation(document.querySelector('#particle-animation'))
  }
}
</script>

<style>
canvas {
  position: absolute;
  top: 0;
  left: 0;
  z-index: 0;
  width: 100%;
  height: 100%;
  pointer-events: none;
}
</style>
