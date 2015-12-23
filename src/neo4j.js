var seraph = require("seraph");

module.exports = function(neo4jConnection) {
  var n4j = seraph(neo4jConnection);

  return {
    query: function(queryString, params) {
      return new Promise(function(resolve, reject) {
        n4j.query(queryString, params, function(err, result) {
          if (err) {
            reject(err);
            return;
          }

          resolve(result);
        });
      });
    },
    getUser: function(username) {
      var cypher = "MATCH (p:Person { username: {username} }) RETURN p",
        params = { username: username };

      return query(cypher, params);
    }
  };
};

module.exports.$inject = ["neo4jConnection"];
