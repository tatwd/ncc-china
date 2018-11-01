var express = require('express');
var bodyParser = require('body-parser');
var mongoose = require('mongoose');
var router = require('./router');
var app = express();
var port = process.env.PORT || 5003;
var databaseName = 'postsys';
var connectionString = `mongodb://localhost:27017/${databaseName}`;

// connet mongodb
mongoose.connect(
  connectionString,
  function(err) {
    if (err) console.log(err.message);
  }
);

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

// register routes
app.use('/api', router);

// start the server
app.listen(port, function() {
  console.log(`The server is listening on http://localhost:${port}`);
});
