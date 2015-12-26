var authentication = function(readModel, credentials) {
	return {
		deserializeUser: function(username, cb) {
			readModel.getUser(username)
			.then(function(result) {
				cb(null, result);
			})
			.catch(function(err) {
				cb(err, null);
			});
		},
		serializeUser: function(user, cb) {
			cb(null, user.username);
		},
		login: function(username, password, cb) {
			readModel.getUser(username)
			.then(function(user) {
				if (!credentials.validatePassword(user, password)) {
					return cb(null, false);
				}

				return cb(null, user);
			})
			.catch(function(err) {
				return cb(null, false);  
			});
		}
	};
};

authentication.$inject = ['readModel', 'credentials'];

module.exports = authentication;
