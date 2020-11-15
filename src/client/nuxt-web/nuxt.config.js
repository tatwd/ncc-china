const pkg = require('./package')

module.exports = {
  telemetry: false,

  head: {
    title: pkg.name,
    meta: [
      {
        charset: 'utf-8'
      },
      {
        name: 'viewport',
        content: 'width=device-width, initial-scale=1'
      },
      {
        hid: 'description',
        name: 'description',
        content: pkg.description
      }
    ],
    link: [
      {
        rel: 'icon',
        type: 'image/x-icon',
        href: '/favicon.ico'
      },
      {
        rel: 'stylesheet',
        href: 'https://fonts.googleapis.com/css?family=Open+Sans|Roboto'
      }
    ]
  },

  loading: {
    color: '#fff'
  },

  css: [
    'element-ui/lib/theme-chalk/index.css',
    // 'element-ui/lib/theme-chalk/display.css',
    'mavon-editor/dist/css/index.css',
    '~/assets/css/style.css',
    '~/assets/css/ele.css'
  ],

  plugins: [
    // https://github.com/ElemeFE/element/issues/15261
    // { src: '@/plugins/element-ui', ssr: false },
    '@/plugins/element-ui',
    {
      src: '@/plugins/mavon-editor',
      ssr: false
    },
    '@/plugins/axios',
    '@/plugins/filters'
  ],

  modules: ['@nuxtjs/axios'],
  axios: {
    baseURL: 'http://localhost:6660/api/'
  },

  build: {
    extractCSS: true,
    extend(config, ctx) {
      // Run ESLint on save
      if (ctx.isDev && ctx.isClient) {
        config.module.rules.push({
          enforce: 'pre',
          test: /\.(js|vue)$/,
          loader: 'eslint-loader',
          exclude: /(node_modules)/
        })
      }
    }
  }
}
