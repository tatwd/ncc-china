var { Comment } = require('../models');
var mapComment = require('../utils/mapComment');
var message = require('../message');

async function getCommentsByPostId(post_id, res) {
  Comment.aggregate([
    {
      $match: { post_id }
    },
    {
      $lookup: {
        from: 'comments',
        localField: 'reply_to',
        foreignField: '_id',
        as: 'reply_to'
      }
    },
    { $unwind: { path: '$reply_to', preserveNullAndEmptyArrays: true } }
  ])
  .exec(function(err, comments) {
    if (err) res.sendStatus(400).send(message.failed(err));
    else res.json(message.succeeded(comments.map(mapComment)));
  });
}

module.exports = {
  get(req, res) {
    var { post_id } = req.params;
    if (post_id) getCommentsByPostId(post_id, res);
    else res.sendStatus(400).send(message.failed('please set `post_id` value'));
  },

  post(req, res) {
    if (!req.body) {
      return res
        .sendStatus(400)
        .send(message.failed('please set request body'));
    }
    var { post_id } = req.params;

    // TODO: check for post_id

    var comment = new Comment(req.body);
    comment.post_id = post_id;
    comment.save(function(err) {
      if (err) res.sendStatus(400).send(message.failed(err));
      else res.json(message.succeeded(comment._id));
    });
  }
};
