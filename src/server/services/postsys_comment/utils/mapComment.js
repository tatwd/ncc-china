function mapComment(schema) {
  return {
    id: schema._id,
    postId: schema.post_id,
    replyTo: schema.reply_to,
    owner: {
      id: schema.owner.id,
      username: schema.owner.username,
      email: schema.owner.email,
      avatarUrl: schema.owner.avatar_url
    },
    text: schema.text,
    utcCreated: schema.utc_created
  };
}

module.exports = mapComment;
