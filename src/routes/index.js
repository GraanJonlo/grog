var express = require('express'),
  container = require('../container'),
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

module.exports = router;
