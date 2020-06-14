var app = require('./app');
var port = process.env.PORT || 5003;

// start the server
app.listen(port, function() {
  console.log(`The server is listening on http://localhost:${port}`);
});
