var Browser = require('zombie'),
  http = require('http'),
  container = require('../src/container'),
  server;

require('should');

Browser.localhost('localhost', 5000);

container.register("neo4jConnection", {
  server: "http://localhost:7474",
  user:"neo4j",
  pass:"neo4j"
});

describe("smoke tests", function() {
  var browser = new Browser();

  before(function() {
    var app = require('../src/app'),
      port = 5000;
    app.set('port', port);
    server = http.createServer(app);
    server.listen(port);
  });

  after(function(done) {
    server.close(done);
  });

  describe("browses to home page", function() {
    before(function() {
      return browser.visit('/');
    });

    it('should be successful', function() {
      browser.assert.success();
    });
  });
});
