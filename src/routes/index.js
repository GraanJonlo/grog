var express = require('express'),
  container = require('../container'),
  router = express.Router();

router.get('/', function(req, res){
  res.render('home', {
    title: 'Home'
  });
});

module.exports = router;
