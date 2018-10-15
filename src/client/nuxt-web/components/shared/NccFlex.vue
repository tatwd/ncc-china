<template>
  <el-row
    :justify="justify"
    :align="align"
    type="flex"
  >
    <slot/>
  </el-row>
</template>

<script>
export default {
  props: {
    justify: {
      type: String,
      default: 'start'
    },
    align: {
      type: String,
      default: 'start'
    }
  }
}
</script>
