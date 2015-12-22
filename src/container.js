var container = require('intravenous').create(),
  server = process.env.NEO4J_SERVER || "http://localhost:7474",
  user = process.env.NEO4J_USER || "neo4j",
  pass = process.env.NEO4J_PASS || "neo4j";

container.register('authentication', require('./authentication'));

container.register("neo4jConnection", {
  server: server,
  user: user,
  pass: pass
});

container.register('readModel', require('./readModel'));

module.exports = container;
