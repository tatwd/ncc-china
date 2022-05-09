var express = require("express");
var bodyParser = require("body-parser");
var mongoose = require("mongoose");
var router = require("./router");
var app = express();
var { nccPostsysDbConn, jaegerCollectorEndpoint } = require("./config");
const createJaegerMiddleware = require("./middleware/jaeger");

// connet mongodb
mongoose.connect(
  nccPostsysDbConn,
  {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  },
  function (err) {
    if (err) console.log(err.message);
  }
);

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(
  createJaegerMiddleware(
    // See https://github.com/chankamlam/express-jaeger#config for more details.
    {
      serviceName: "ncc-api-postsys_comment",
      sampler: {
        type: "const",
        param: 1,
      },
      reporter: {
        collectorEndpoint: jaegerCollectorEndpoint,
      },
    },
    {
      baggagePrefix: "",
      excludePath: []
    }
  )
);

// register routes
app.use("/api", router);

module.exports = app;
