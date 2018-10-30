var express = require('express');
var router = express.Router();
var commentController = require('./controllers/comment');

// middleware to use for all requests
router.use(function(req, res, next) {
  console.log('Something is happening.');
  next();
});

router
  .route('/posts/:post_id/comments')

  // GET /api/:post_id/comments
  .get(commentController.get)

  // POST /api/:post_id/comments
  .post(commentController.post);

module.exports = router;
