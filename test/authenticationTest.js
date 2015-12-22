require('should');

describe('Authentication', function() {
  describe('when serializing a user', function() {
    var user = { username: 'test', displayName: 'Testy McTestTest', password: 'foobar' },
      sut = require('../src/authentication')(),
      expected = 'test',
      actual;

    before(function() {
      sut.serializeUser(user, function(err, result) {
        if(err) {
          throw err;
        }

        actual = result;
      });
    });

    it('should serialize a user to its username', function() {
      actual.should.equal(expected);
    });
  });

  describe('when deserializing a user that exists', function() {
    var user = { username: 'test', displayName: 'Testy McTestTest', password: 'foobar' },
      readModel =  {
        getUser: function(username) {
          return new Promise(function(resolve, reject) {
            if (username!==user.username) {
              reject();
              return;
            }

            resolve(user);
          });
        }
      },
      sut = require('../src/authentication')(readModel),
      actual;

    before(function(done) {
      sut.deserializeUser(user.username, function(err, result) {
        if(err) {
          throw err;
        }

        actual = result;
        done();
      });
    });

    it('should return the user', function() {
      actual.username.should.equal(user.username);
      actual.displayName.should.equal(user.displayName);
      actual.password.should.equal(user.password);
    });
  });

  describe('when deserializing a user that does not exists', function() {
    var readModel =  {
        getUser: function(username) {
          return new Promise(function(resolve, reject) {
            reject(new Error('User not found'));
          });
        }
      },
      sut = require('../src/authentication')(readModel),
      actual;

    before(function(done) {
      sut.deserializeUser('zgkasdgl', function(err, result) {
        actual = err;
        done();
      });
    });

    it('should return an error', function() {
      actual.message.should.equal('User not found');
    });
  });
});
