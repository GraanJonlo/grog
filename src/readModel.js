function userMapper(neo4jRow) {
  var user = {
    username: neo4jRow.username,
    displayName: neo4jRow.displayName,
    password: neo4jRow.password
  };

  return user;
}

module.exports = function(neo4j) {
  return {
    getUser: function(username) {
      return new Promise(function(resolve, reject) {
        neo4j.getUser(username)
        .then(function(results) {
          if (results.length === 0) {
            reject(new Error('User not found'));
            return;
          }
          
          var users = results.map(userMapper);
          resolve(users[0]);
        })
        .catch(function(err) {
          reject(err);
        });
      });
    }
  }
}

module.exports.$inject = ["neo4j"];
