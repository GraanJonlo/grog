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
		login: function(req, username, password, cb) {
			readModel.getUser(username)
			.then(function(user) {
				if (!credentials.validatePassword(user, password)) {
					return cb(null, false, req.flash('message', 'Invalid Password'));
				}

				return cb(null, user);
			})
			.catch(function(err) {
				return cb(null, false, req.flash('message', 'User not found.'));  
			});
		}
	};
};

authentication.$inject = ['readModel', 'credentials'];

module.exports = authentication;
