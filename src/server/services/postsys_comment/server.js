var express = require('express');
var bodyParser = require('body-parser');
var mongoose = require('mongoose');

// import models
// var { Comment } = require('./models');

var app = express();
var db = 'test';
var connectionString = `mongodb://localhost:27017/${db}`;

// connect mongodb

mongoose.connect(
  connectionString,
  function(err) {
    if (err) console.log(err.message);
  }
);

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var port = process.env.PORT || 5003;

// routes for the api
var router = express.Router();

// middleware to use for all requests
router.use(function(req, res, next) {
  // do logging
  console.log('Something is happening.');
  next(); // make sure we go to the next routes and don't stop here
});

router.get('/', function(req, res) {
  res.json({
    message: 'welcome to postsys_comment api!'
  });
});

// more routes here

// register routes
app.use('/api', router);

// start the server
app.listen(port, function() {
  console.log(`The server is listening on http://localhost:${port}`);
});
