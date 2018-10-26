var mongoose = require('mongoose');

var Schema = mongoose.Schema;

var CommentSchema = new Schema({
  id: Schema.Types.ObjectId,
  postId: ObjectId, 
  owner: {
    id: String,
    username: String,
    email: String,
    avatarUrl: String
  },
  text: String,
  // TODO
});

module.exports = mongoose.model('Bear', CommentSchema);