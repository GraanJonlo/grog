var express = require('express'),
  container = require('../container'),
  passport = container.get('passport'),
  router = express.Router();

router.get('/', function(req, res){
  res.render('home', {
    title: 'Home'
  });
});

router.get('/signin', function(req, res) {
  res.render('signin', {
    message: req.flash('message'),
    title: 'Signin'
  });
});

router.post('/login', passport.authenticate('local', { successRedirect: '/', failureRedirect: '/signin' }));

module.exports = router;
