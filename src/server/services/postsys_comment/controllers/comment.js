var { Schema } = require('mongoose');
var { Comment } = require('../models');
var mapComment = require('../utils/mapComment');
var message = require('../message');
var jwt = require('jsonwebtoken');
var { secretKey } = require('../config');

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
  ]).exec(function(err, comments) {
    if (err) res.send(400, message.failed(err));
    else res.json(message.succeeded(comments.map(mapComment)));
  });
}

module.exports = {
  get(req, res) {
    var { post_id } = req.params;
    if (post_id) getCommentsByPostId(post_id, res);
    else res.send(400, message.failed('please set `post_id` value'));
  },

  getCommentsOfCurrentUser(req, res) {
    jwt.verify(req.token, secretKey, function(err, data) {
      if (err) {
        res.send(403, message.failed('token invalid'));
      } else {
        var username = data.sub;
        Comment.find({ 'owner.username': username }, function(err, comments) {
          if (err) res.send(400, message.failed(err));
          else {
            var data = comments.map(mapComment);
            res.json(message.succeeded(data));
          }
        });
      }
    });
  },

  post(req, res) {
    if (!req.body) {
      return res.send(400, message.failed('please set request body'));
    }
    var { post_id } = req.params;

    // TODO: check for post_id

    var comment = new Comment(req.body);
    comment.post_id = post_id;
    comment.save(function(err) {
      if (err) res.send(400, message.failed(err));
      else res.json(message.succeeded(comment._id));
    });
  },

  delete(req, res) {
    jwt.verify(req.token, secretKey, function(err, data) {
      if (err) {
        res.send(403, message.failed('token invalid'));
      } else {
        var username = data.sub;
        var { id } = req.params;
        Comment.deleteOne(
          { 'owner.username': username, id: Schema.Types.ObjectId(id) },
          function(err) {
            if (err) res.send(400, message.failed(err));
            else res.json(message.succeeded('succeeded to delete'));
          }
        );
      }
    });
  }
};
