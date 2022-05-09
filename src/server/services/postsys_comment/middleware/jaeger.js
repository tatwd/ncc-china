const jaeger = require("@chankamlam/express-jaeger");

module.exports = function(config, options) {
  return jaeger(config, options, (req, res) => {
    // here to write your code
    // which is showing here is to auto record query/body/path for every request
    const jaeger = req.jaeger;
    jaeger.setTag("route", req.path);
    jaeger.setTag("body", req.body);
    jaeger.setTag("query", req.query);
  })
};
