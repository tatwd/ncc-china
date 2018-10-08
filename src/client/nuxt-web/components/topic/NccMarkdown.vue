<template>
  <div id="ncc-markdown">
    <el-card
      class="box-card"
      shadow="hover"
    >
      <div
        slot="header"
        class="clearfix"
      >
        <span>Markdown 语法参考</span>
      </div>
      <div>
        <p>### 单行的标题</p>
        <p>**粗体**</p>
        <p>`console.log('行内代码')`</p>
        <p>```js\n code \n``` 标记代码块</p>
        <p>[内容](链接)</p>
        <p>![文字说明](图片链接)</p>
        <a href="https://www.ituring.com.cn/article/775">Markdown文档</a>
      </div>
    </el-card>
  </div>
</template>

<style scoped>
#ncc-markdown p {
  margin-top: 0;
}
</style>
