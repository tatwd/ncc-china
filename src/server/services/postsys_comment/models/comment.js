var mongoose = require('mongoose');

var Schema = mongoose.Schema;
var ObjectId = Schema.Types.ObjectId;

var OwnerSchema = new Schema(
  {
    id: String,
    username: String,
    email: String,
    avatar_url: {
      type: String,
      alias: 'avatarUrl'
    }
  },
  { _id: false }
);

var CommentSchema = new Schema({
  post_id: {
    type: String,
    alias: 'postId'
  },
  reply_to: {
    type: ObjectId,
    alias: 'replyTo',
    default: null
  },
  // comment_id: {
  //   type: ObjectId,
  //   alias: 'commentId',
  //   default: null
  // },
  owner: OwnerSchema,
  text: String,
  utc_created: {
    type: Date,
    default: Date.now(),
    alias: 'utcCreated'
  },
  is_deleted: {
    type: Boolean,
    default: false,
    alias: 'isDeleted'
  }
});

module.exports = mongoose.model('Comment', CommentSchema);
