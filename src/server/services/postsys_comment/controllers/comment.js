var { Comment } = require('../models');
var mapComment = require('../utils/mapComment');

module.exports = {

  // GET /api/comments
  get(req, res) {
    Comment.find(function(err, comments) {
      if (err) res.sendStatus(400).send({ error: err });
      else res.json({
        code: 0,
        data: comments.map(mapComment),
        message: 'succeeded'
      });
    });
  },

  // POST /api/comments
  post(req, res) {
    if (!req.body) {
      return res
        .sendStatus(400)
        .send({ error: 'faild:please set request body' });
    }
    var comment = new Comment(req.body);
    comment.save(function(err) {
      if (err) res.sendStatus(400).send({ error: err });
      else res.json({
        code: 0,
        data: comment._id,
        message: 'succeeded'
      });
    });
  }
}