var { Comment } = require('../models');
var mapComment = require('../utils/mapComment');
var message = require('../message');

function getComments(res) {
  Comment.find(function(err, comments) {
    if (err) res.sendStatus(400).send(message.failed(err));
    else res.json(message.succeeded(comments.map(mapComment)));
  });
}

function getCommentsByPostId(post_id, res) {
  Comment.find({ post_id }, function(err, comments) {
    if (err) res.sendStatus(400).send(message.failed(err));
    else res.json(message.succeeded(comments.map(mapComment)));
  });
}

module.exports = {
  // GET /api/comments
  get(req, res) {
    var { post_id } = req.query;
    if (!post_id) getComments(res);
    else getCommentsByPostId(post_id, res);
  },

  // POST /api/comments
  post(req, res) {
    if (!req.body) {
      return res
        .sendStatus(400)
        .send(message.failed('please set request body'));
    }
    var comment = new Comment(req.body);
    comment.save(function(err) {
      if (err) res.sendStatus(400).send(message.failed(err));
      else res.json(message.succeeded(comment._id));
    });
  }
};
