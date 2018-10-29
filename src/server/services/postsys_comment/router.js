var express = require('express');
var router = express.Router();
var commentController = require('./controllers/comment');

// middleware to use for all requests
router.use(function(req, res, next) {
  console.log('Something is happening.');
  next();
});

router
  .route('/comments')
  .get(commentController.get)
  .post(commentController.post);

// router
//   .route('/posts/:post_id/comments')
//   .get(commentController.get);

module.exports = router;