var express = require('express');
var verifyToken = require('./utils/verifyToken');
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

router
  .route('/users/:user_id/comments')

  // GET /api/users/:user_id/comments
  .get(commentController.getCommentsByUserId)

router
  .route('/comments')

  // GET /api/comments
  .get(verifyToken, commentController.getCommentsOfCurrentUser)

router
  .route('/comments/:id')

   // DELETE /api/:post_id/comments
   .delete(verifyToken, commentController.delete);

module.exports = router;
