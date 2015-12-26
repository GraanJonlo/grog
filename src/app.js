var bodyParser = require('body-parser'),
  cookieParser = require('cookie-parser'),
  express = require('express'),
  flash = require('connect-flash'),
  logger = require('morgan'),
  path = require('path'),
  sassMiddleware = require('node-sass-middleware'),
  useragent = require('express-useragent'),
  container = require('./container'),
  passport = container.get('passport'),
  routes = require('./routes/index'),
  session = require('./session'),
  app = express();

app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

app.locals.moment = require('moment');
app.locals.sanitizeHtml = require('sanitize-html');

app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(cookieParser());
app.use(flash());
app.use(useragent.express());

app.use(sassMiddleware({
  src: __dirname + '/sass',
  dest: __dirname + '/public/stylesheets',
  debug: true,
  outputStyle: 'expanded',
  prefix: '/stylesheets'
}));

app.use(express.static(__dirname + '/public'));

app.use(session);

app.use(passport.initialize());
app.use(passport.session());

app.use('/', routes);

module.exports = app;
