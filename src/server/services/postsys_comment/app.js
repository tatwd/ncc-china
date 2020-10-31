var express = require('express');
var bodyParser = require('body-parser');
var mongoose = require('mongoose');
var router = require('./router');
var app = express();
var {nccPostsysDbConn} = require('./config')

// connet mongodb
mongoose.connect(
  nccPostsysDbConn,
  {
    useNewUrlParser: true,
    useUnifiedTopology: true
  },
  function(err) {
    if (err) console.log(err.message);
  }
);

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

// register routes
app.use('/api', router);

module.exports = app
