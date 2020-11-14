import Vue from 'vue'

export function timeAgo(time) {
  const between = Date.now() / 1000 - Number(new Date(time).getTime() / 1000)
  if (between < 60) return '刚刚'
  if (between < 3600) return pluralize(~~(between / 60), ' 分钟')
  if (between < 86400) return pluralize(~~(between / 3600), ' 小时')
  return pluralize(~~(between / 86400), ' 天')
}

function pluralize(time, label) {
  return time + label
}

const filters = {
  timeAgo
}

export default filters

Object.keys(filters).forEach(key => {
  Vue.filter(key, filters[key])
})
