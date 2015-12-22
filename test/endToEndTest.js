var Browser = require('zombie'),
  http = require('http'),
  seraph = require('seraph'),
  container = require('../src/container'),
  neo4jConnection = {
	  server: "http://localhost:7474",
	  user:"neo4j",
	  pass:"neo4j"
	},
  n4j = seraph(neo4jConnection),
  server;

require('should');

Browser.localhost('localhost', 5000);

container.register("neo4jConnection", neo4jConnection);

describe("end to end tests", function() {
  var browser = new Browser();

  before(function() {
    var app = require('../src/app'),
      port = 5000;
    app.set('port', port);
    server = http.createServer(app);
    server.listen(port);
  });

  after(function(done) {
    server.close(function() {
      tearDownDb()
      .then(function(result) {
        done();
      })
      .catch(function(err) {
        done(err);
      })
    });
  });

  describe("existing author", function() {
  	var author;

    before(function(done) {
      Author()
      .create()
      .then(function(result) {
        author = result;
        done();
      }).
      catch(function(err) {
        done(err);
      });
    });

    describe('navigates to signin', function() {
      before(function(done) {
        browser.visit('/signin', done);
      });

      it('should be successful', function() {
        browser.assert.success();
      });

      it('should see signin page', function() {
        browser.assert.text('title', 'Sign In');
      });

      describe('submits credentials', function() {
        before(function(done) {
          browser
          .fill('username', author.username)
          .fill('password', author.password)
          .pressButton('Sign In', done);
        });

        it('should be successful', function() {
          browser.assert.success();
        });

        it('should see home page', function() {
          browser.assert.text('title', 'Home');
        });
      });
    });

  	// submit credentials
  	// assert db called with credentials
  	// assert page shows logged in
  	// navigate to post editor
  	// fill in slug, title and content
  	// click publish
  	// assert db called
  	// assert page show successful
  	// navigate to home page
  	// assert first post is THE post
  });
});

function Author() {
  return {
    username: 'test',
    displayName: 'Testy McTestTest',
    password: 'foobar',
    create: function() {
      var params = {
        username: this.username,
        displayName: this.displayName,
        password: this.password
      };

      return new Promise(function(resolve, reject) {
        var query = "CREATE (p:Person:Author {username: {username}, displayName: {displayName}, password: {password}})";

        n4j.query(query, params, function(err, result) {
          if (err) {
            reject(err);
            return;
          }

          resolve(params);
        });
      });
    }
  };
}

function tearDownDb() {
  var query = "MATCH (n) DETACH DELETE n",
    params = {};

  return new Promise(function(resolve, reject) {
    n4j.query(query, params, function(err, result) {
      if (err) {
        reject(err);
        return;
      }

      resolve(result);
    });
  });
}
